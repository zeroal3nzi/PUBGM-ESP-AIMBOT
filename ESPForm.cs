using System;
using System.Text;
using GameOverlay.Drawing;
using GameOverlay.Windows;
using SharpDX;
using Point = GameOverlay.Drawing.Point;
using Color = GameOverlay.Drawing.Color;
using Rectangle = GameOverlay.Drawing.Rectangle;
using RawVector2 = SharpDX.Mathematics.Interop.RawVector2;
using ShpVector3 = SharpDX.Vector3;
using ShpVector2 = SharpDX.Vector2;
using System.Linq;
using System.Runtime.InteropServices;

namespace PUBGMESP
{
    public interface IESPForm
    {
        void Initialize();
        void Update();
    }

    public class ESPForm : IESPForm
    {
        public readonly OverlayWindow _window;
        private readonly Graphics _graphics;
        private readonly GameMemSearch _ueSearch;

        private Font _font;
        private Font _infoFont;
        private Font _bigfont;
        private SolidBrush _black;
        private SolidBrush _red;
        private SolidBrush _green;
        private SolidBrush _blue;
        private SolidBrush _orange;
        private SolidBrush _purple;
        private SolidBrush _yellow;
        private SolidBrush _white;
        private SolidBrush _transparent;
        private SolidBrush _txtBrush;
        private SolidBrush[] _randomBrush;
        private SolidBrush _boxBrush;


        private DisplayData _data;
        private int playerCount;

        // offset
        private int actorOffset, boneOffset, tmpOffset;

        private float fClosestDist;
        private long BestTargetUniqID = -1;
        private static float deltamult = 8f;
        private static float offset_check_result = 0f;

        public ESPForm(RECT rect, GameMemSearch ueSearch)
        {
            this._ueSearch = ueSearch;

            _window = new OverlayWindow(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top)
            {
                IsTopmost = true,
                IsVisible = true
            };

            _window.SizeChanged += _window_SizeChanged;

            _graphics = new Graphics
            {
                MeasureFPS = true,
                Height = _window.Height,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true,
                UseMultiThreadedFactories = false,
                VSync = true,
                Width = _window.Width,
                WindowHandle = IntPtr.Zero
            };

            // offset
            actorOffset = 320;
            boneOffset = 1408;
            tmpOffset = 776;
        }

        ~ESPForm()
        {
            _graphics.Dispose();
            _window.Dispose();
        }

        public void Initialize()
        {
            _window.CreateWindow();

            _graphics.WindowHandle = _window.Handle;
            _graphics.Setup();

            _font = _graphics.CreateFont("Microsoft YaHei", 10);
            _infoFont = _graphics.CreateFont("Microsoft YaHei", 12);
            _bigfont = _graphics.CreateFont("Microsoft YaHei", 18, true);

            _black = _graphics.CreateSolidBrush(0, 0, 0);
            _red = _graphics.CreateSolidBrush(255, 99, 71);
            _green = _graphics.CreateSolidBrush(Color.Green);
            _blue = _graphics.CreateSolidBrush(135, 206, 250);
            _orange = _graphics.CreateSolidBrush(255, 97, 0);
            _purple = _graphics.CreateSolidBrush(255, 105, 180);
            _yellow = _graphics.CreateSolidBrush(255, 255, 0);
            _white = _graphics.CreateSolidBrush(255, 255, 255);
            _transparent = _graphics.CreateSolidBrush(0, 0, 0, 0);
            _randomBrush = new SolidBrush[]
            {
                _orange,_red,_green,_blue,_yellow,_white,_purple
            };
            _txtBrush = _graphics.CreateSolidBrush(0, 0, 0, 0.5f);
        }

        public void UpdateData(DisplayData data)
        {
            _data = data;
        }

        public void Update()
        {
            var gfx = _graphics;
            gfx.BeginScene();
            gfx.ClearScene(_transparent);
            // Draw FPS
            //gfx.DrawTextWithBackground(_font, _red, _black, 10, 10, "FPS: " + gfx.FPS);
            

            if (_data.Players.Length > 0)
            {
                playerCount = _data.Players.Length;
                DrawShadowText(gfx, _bigfont, _red, new Point(_window.Width / 2 - 40f, 40f), "Enemy near  :  " + playerCount);
            }
            // Read View Matrix
            long viewMatrixAddr = Mem.ReadMemory<int>(Mem.ReadMemory<int>(_data.ViewMatrixBase) + 32) + 512;
            D3DMatrix viewMatrix = Algorithms.ReadViewMatrix(viewMatrixAddr);
            float fClosestDist = -1;
            // Draw Player ESP
            if (Settings.PlayerESP)
            {
                foreach (var player in _data.Players)
                {

                    //if (player.Health <= 0) continue;
                    if (Algorithms.WorldToScreenPlayer(viewMatrix, player.Position, out ShpVector3 playerScreen, out int distance, _window.Width, _window.Height))
                    {
                        // Too Far not render
                        if (distance > 500) continue;
                        float x = playerScreen.X;
                        float y = playerScreen.Y;
                        float h = playerScreen.Z;
                        float w = playerScreen.Z / 2;

                        try
                        {
                            _boxBrush = _randomBrush[player.TeamID % 7];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            _boxBrush = _green;
                        }
                        //DrawShadowText(gfx,_font, _green, new Point((x - playerScreen.Z / 4) - 3, y - 15), player.Pose.ToString());

                        // Adjust Box
                        if (player.Pose == 1114636288)
                        {
                            y = playerScreen.Y + playerScreen.Z / 5;
                            h -= playerScreen.Z / 5;
                        }
                        if (player.Pose == 1112014848 || player.Status == 7)
                        {
                            y = playerScreen.Y + playerScreen.Z / 4;
                            h -= playerScreen.Z / 4;
                        }

                        // Draw Info
                        StringBuilder sb = new StringBuilder("[");
                        if (player.IsRobot)
                            sb.Append("[Bot] ");
                        sb.Append(player.Name);
                        DrawShadowText(gfx, _infoFont, _boxBrush, new Point(x + w / 2, y - 5), sb.ToString());
                        // Draw Distance
                        sb = new StringBuilder("[");
                        sb.Append(distance).Append("M]");
                        DrawShadowText(gfx, _font, _boxBrush, new Point(x + w / 2, y + 7), sb.ToString());

                        if (Settings.PlayerBox)
                        {
                            // Draw Box
                            gfx.DrawRectangle(_boxBrush, Rectangle.Create(x - playerScreen.Z / 4 - 3, y - 5, w + 3, h + 5), 1);
                        }
                        if (Settings.Player3dBox)
                        {
                            Draw3DBox(viewMatrix, player, playerScreen, _window.Width, _window.Height, 180f);
                            // Draw Box
                            //gfx.DrawRectangle(_boxBrush, Rectangle.Create(x - playerScreen.Z / 4 - 3, y - 5, w + 3, h + 5), 1);
                        }
                        if (Settings.PlayerBone)
                        {
                            // Draw Bone
                            long tmpAddv = Mem.ReadMemory<int>(player.Address + tmpOffset);
                            long bodyAddv = tmpAddv + actorOffset;
                            long boneAddv = Mem.ReadMemory<int>(tmpAddv + boneOffset) + 48;
                            DrawPlayerBone(bodyAddv, boneAddv, w, viewMatrix, _window.Width, _window.Height);
                        }
                        if (Settings.PlayerHealth)
                        {

                            // Draw Health
                            DrawPlayerBlood((x - playerScreen.Z / 4) - 8, y - 5, h + 5, 3, player.Health);
                        }
                        if (Settings.PlayerLines)
                        {
                            // Draw Line
                            gfx.DrawLine(_white, new Line(_window.Width / 2, 0, x, y), 2);
                        }
                    }
                    float ScreenCenterX = (float)_window.Width / 2f, ScreenCenterY = (float)_window.Height / 2f;

                    if (Settings.aimEnabled)
                    {
                        long tmpAddv = Mem.ReadMemory<int>(player.Address + tmpOffset);
                        long bodyAddv = tmpAddv + actorOffset;
                        long boneAddv = Mem.ReadMemory<int>(tmpAddv + boneOffset) + 48;
                        ShpVector3 headPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 5 * 48);

                        headPos.Z += 7;

                        var clampPos = headPos - player.Position;
                        bool w2sHead = Algorithms.WorldToScreen3DBox(viewMatrix, new ShpVector3(headPos.X, headPos.Y - (Settings.bPredict * 2), headPos.Z - (Settings.bYAxis * 8)), out ShpVector2 HeadPosition, _window.Width, _window.Height);

                        player.Screen2D = HeadPosition;
                        player.CrosshairDistance = ShpVector2.Distance(HeadPosition, new ShpVector2(ScreenCenterX, ScreenCenterY));


                        if (Algorithms.isInside(ScreenCenterX, ScreenCenterY, Settings.bFovArray[Settings.bFovInt], player.Screen2D.X, player.Screen2D.Y))
                        {
                            fClosestDist = player.CrosshairDistance;
                            BestTargetUniqID = player.Address;
                            player.IsIn = true;
                        }


                    }
                    if (Settings.bDrawFow)
                    {
                        gfx.DrawCircle(_red, ScreenCenterX, ScreenCenterY, Settings.bFovArray[Settings.bFovInt], 1);
                    }
                }
            }
            if (MainForm.GetAsyncKeyState(Settings.bAimKeys[Settings.bAimKeyINT]))
            {
                if (BestTargetUniqID != -1)
                {

                    var aimTarget = (from x in _data.Players.ToList()
                                     where x != null
                                     where x.IsIn
                                     orderby x.CrosshairDistance
                                     select x).FirstOrDefault();
                    if (aimTarget != null)
                    {
                        BestTargetUniqID = aimTarget.Address;
                    }

                    var best = FindAimTargetByUniqueID(_data.Players, BestTargetUniqID);

                    if (best != null)
                    {
                        {
                            var roundPos = new ShpVector2(best.Screen2D.X, best.Screen2D.Y);
                            AimAtPosV2(roundPos.X, roundPos.Y);

                        }
                    }
                }
            }
            else
            {
                BestTargetUniqID = -1;
            }
            // Draw Item ESP
            if (Settings.ItemESP)
            {
                foreach (var item in _data.Items)
                {
                    if (Algorithms.WorldToScreenItem(viewMatrix, item.Position, out ShpVector2 itemScreen, out int distance, _window.Width, _window.Height))
                    {
                        // Too Far not render
                        if (distance > 100) continue;
                        // Draw Item
                        string disStr = string.Format("[{0}m]", distance);
                        DrawShadowText(gfx, _font, _yellow, new Point(itemScreen.X, itemScreen.Y), item.Name);
                        DrawShadowText(gfx, _font, _yellow, new Point(itemScreen.X, itemScreen.Y + 10), disStr);
                    }
                }
                foreach (var box in _data.Boxes)
                {
                    if (Algorithms.WorldToScreenItem(viewMatrix, box.Position, out ShpVector2 itemScreen, out int distance, _window.Width, _window.Height))
                    {
                        // Too Far not render
                        if (distance > 100) continue;
                        DrawShadowText(gfx, _font, _yellow, new Point(itemScreen.X, itemScreen.Y), "Lootbox [" + distance.ToString() + "M]");
                    }
                }
            }
            // Draw Vehicle ESP
            if (Settings.VehicleESP)
            {
                foreach (var car in _data.Vehicles)
                {
                    if (Algorithms.WorldToScreenItem(viewMatrix, car.Position, out ShpVector2 carScreen, out int distance, _window.Width, _window.Height))
                    {
                        // Too Far not render
                        if (distance > 300) continue;
                        string disStr = string.Format("[{0}m]", distance);
                        // Draw Car
                        DrawShadowText(gfx, _font, _blue, new Point(carScreen.X, carScreen.Y), car.Name);
                        DrawShadowText(gfx, _font, _blue, new Point(carScreen.X, carScreen.Y + 10), disStr);
                    }
                }
            }
            // Grenade alert
            foreach (var gre in _data.Grenades)
            {
                if (Algorithms.WorldToScreenItem(viewMatrix, gre.Position, out ShpVector2 greScreen, out int distance, _window.Width, _window.Height))
                {
                    DrawShadowText(gfx, _font, 15, _red, new Point(greScreen.X, greScreen.Y), string.Format("!!! {0} !!! [{1}M]", gre.Type.GetDescription(), distance));
                }
            }
            gfx.EndScene();
        }
        private static PlayerData FindAimTargetByUniqueID(PlayerData[] array, long address)
        {
            var entityList = array;
            for (int i = 0; i < entityList.Length; i++)
            {
                var current = entityList[i];
                if (current == null)
                    continue;

                if (current.Address == address)
                    return current;
            }
            return null;
        }

        private void AimAtPosV2(float x, float y)
        {
            int num = _window.Width / 2;
            int num2 = _window.Height / 2;
            float num3 = (float)Settings.bSmooth + 1f;
            float num4 = 0f;
            float num5 = 0f;
            _graphics.DrawCircle(_white, x, y, 3f, 3f);
            if (x != 0f)
            {
                if (x > (float)num)
                {
                    num4 = -((float)num - x);
                    num4 /= num3;
                    if (num4 + (float)num > (float)(num * 2))
                    {
                        num4 = 0f;
                    }
                }
                if (x < (float)num)
                {
                    num4 = x - (float)num;
                    num4 /= num3;
                    if (num4 + (float)num < 0f)
                    {
                        num4 = 0f;
                    }
                }
            }
            if (y != 0f)
            {
                if (y > (float)num2)
                {
                    num5 = -((float)num2 - y);
                    num5 /= num3;
                    if (num5 + (float)num2 > (float)(num2 * 2))
                    {
                        num5 = 0f;
                    }
                }
                if (y < (float)num2)
                {
                    num5 = y - (float)num2;
                    num5 /= num3;
                    if (num5 + (float)num2 < 0f)
                    {
                        num5 = 0f;
                    }
                }
            }
            if (Math.Abs(num4) < 1f)
            {
                if (num4 > 0f)
                {
                    deltamult = offset_check_result * 100f;
                }
                if (num4 < 0f)
                {
                    deltamult = offset_check_result * 10f;
                }
            }
            if (Math.Abs(num5) < 1f)
            {
                if (num5 > 0f)
                {
                    deltamult = offset_check_result * 10f;
                }
                if (num5 < 0f)
                {
                    deltamult = offset_check_result * 10f;
                }
            }

            MouseMove((int)num4, (int)num5);//, 0U, UIntPtr.Zero);
        }
        public static void MouseMove(int deltaX, int deltaY)
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_MOVE,
                    dx = deltaX,
                    dy = deltaY,
                },
            };
            SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, ref Input pInputs, int cbSize);
        private void Draw3DBox(D3DMatrix viewMatrix, PlayerData player, ShpVector3 playersc, int winWidth, int winHeight, float hei= 180f)
        {
            float num = 70f;
            float num2 = 60f;
            float num3 = 50f;
            float num4 = 85f;
            hei = 180f;
            ShpVector3 vector = new ShpVector3(num3, -num2 / 2f, 0f);
            ShpVector3 vector2 = new ShpVector3(num3, num2 / 2f, 0f);
            ShpVector3 vector3 = new ShpVector3(num3 - num, num2 / 2f, 0f);
            ShpVector3 vector4 = new ShpVector3(num3 - num, -num2 / 2f, 0f);

            Matrix matrix = Matrix.RotationZ((6.28318548f * (player.Position.Y ) / 180f / 2f));
            ShpVector3 vector5 = new ShpVector3(player.Position.X, player.Position.Y, player.Position.Z - num4);
            vector = ShpVector3.TransformCoordinate(vector, matrix) + vector5;
            vector2 = ShpVector3.TransformCoordinate(vector2, matrix) + vector5;
            vector3 = ShpVector3.TransformCoordinate(vector3, matrix) + vector5;
            vector4 = ShpVector3.TransformCoordinate(vector4, matrix) + vector5;
            ShpVector2 vector6;

            if (!Algorithms.WorldToScreen3DBox(viewMatrix, vector, out vector6,  winWidth, winHeight))
                return;
            ShpVector2 vector7;
            if (!Algorithms.WorldToScreen3DBox(viewMatrix, vector2, out vector7,  winWidth, winHeight))
                return;
            ShpVector2 vector8;
            if (!Algorithms.WorldToScreen3DBox(viewMatrix, vector3, out vector8,  winWidth, winHeight))
                return;
            ShpVector2 vector9;
            if (!Algorithms.WorldToScreen3DBox(viewMatrix, vector4, out vector9,  winWidth, winHeight))
                return;
            
            RawVector2[] array = new RawVector2[]
            {
                vector6,
                vector7,
                vector8,
                vector9,
                vector6
            };
            DrawLines(array, _boxBrush);
            vector.Z += hei;
            
            bool arg_240_0 = Algorithms.WorldToScreen3DBox(viewMatrix, vector, out vector6,  winWidth, winHeight);
            vector2.Z += hei;
            bool flag = Algorithms.WorldToScreen3DBox(viewMatrix, vector2, out vector7, winWidth, winHeight);
            vector3.Z += hei;
            bool flag2 = Algorithms.WorldToScreen3DBox(viewMatrix, vector3, out vector8,  winWidth, winHeight);
            vector4.Z += hei;
            bool flag3 = Algorithms.WorldToScreen3DBox(viewMatrix, vector4, out vector9,  winWidth, winHeight);
            if (!arg_240_0 || !flag || !flag2 || !flag3)
            {
                return;
            }
            RawVector2[] array2 = new RawVector2[]
            {
                vector6,
                vector7,
                vector8,
                vector9,
                vector6
            };
            DrawLines(array2, _boxBrush);
            DrawLine(new RawVector2(array[0].X, array[0].Y), new RawVector2(array2[0].X, array2[0].Y), _boxBrush);
            DrawLine(new RawVector2(array[1].X, array[1].Y), new RawVector2(array2[1].X, array2[1].Y), _boxBrush);
            DrawLine(new RawVector2(array[2].X, array[2].Y), new RawVector2(array2[2].X, array2[2].Y), _boxBrush);
            DrawLine(new RawVector2(array[3].X, array[3].Y), new RawVector2(array2[3].X, array2[3].Y), _boxBrush);
        }
        public void DrawLines( RawVector2[] point0, IBrush gxx)
        {
            if (point0.Length < 2)
            {
                return;
            }
            for (int i = 0; i < point0.Length - 1; i++)
            {
                DrawLine(point0[i], point0[i + 1], _boxBrush);
            }
        }
        public void DrawLine(RawVector2 a, RawVector2 b, IBrush gcolr)
        {
            _graphics.DrawLine(_boxBrush, a.X, a.Y, b.X, b.Y, 1f);
        }
        private void DrawPlayerBone(long bodyAddv, long boneAddv, float w, D3DMatrix viewMatrix, int winWidth, int winHeight)
        {

            float sightX = winWidth / 2, sightY = winHeight / 2;

            ShpVector3 headPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 5 * 48);
            headPos.Z += 7;
            ShpVector2 head;
            Algorithms.WorldToScreenBone(viewMatrix, headPos, out head, out int distance, winWidth, winHeight);
            ShpVector2 neck = head;
            ShpVector2 chest;
            ShpVector3 chestPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 4 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, chestPos, out chest, out distance, winWidth, winHeight);
            ShpVector2 pelvis;
            ShpVector3 pelvisPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 1 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, pelvisPos, out pelvis, out distance, winWidth, winHeight);
            ShpVector2 lSholder;
            ShpVector3 lSholderPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 11 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, lSholderPos, out lSholder, out distance, winWidth, winHeight);
            ShpVector2 rSholder;
            ShpVector3 rSholderPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 32 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, rSholderPos, out rSholder, out distance, winWidth, winHeight);
            ShpVector2 lElbow;
            ShpVector3 lElbowPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 12 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, lElbowPos, out lElbow, out distance, winWidth, winHeight);
            ShpVector2 rElbow;
            ShpVector3 rElbowPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 33 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, rElbowPos, out rElbow, out distance, winWidth, winHeight);
            ShpVector2 lWrist;
            ShpVector3 lWristPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 63 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, lWristPos, out lWrist, out distance, winWidth, winHeight);
            ShpVector2 rWrist;
            ShpVector3 rWristPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 62 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, rWristPos, out rWrist, out distance, winWidth, winHeight);
            ShpVector2 lThigh;
            ShpVector3 lThighPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 52 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, lThighPos, out lThigh, out distance, winWidth, winHeight);
            ShpVector2 rThigh;
            ShpVector3 rThighPos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 56 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, rThighPos, out rThigh, out distance, winWidth, winHeight);
            ShpVector2 lKnee;
            ShpVector3 lKneePos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 53 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, lKneePos, out lKnee, out distance, winWidth, winHeight);
            ShpVector2 rKnee;
            ShpVector3 rKneePos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 57 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, rKneePos, out rKnee, out distance, winWidth, winHeight);
            ShpVector2 lAnkle;
            ShpVector3 lAnklePos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 54 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, lAnklePos, out lAnkle, out distance, winWidth, winHeight);
            ShpVector2 rAnkle;
            ShpVector3 rAnklePos = Algorithms.GetBoneWorldPosition(bodyAddv, boneAddv + 58 * 48);
            Algorithms.WorldToScreenBone(viewMatrix, rAnklePos, out rAnkle, out distance, winWidth, winHeight);

            if (head != null && chest != null && pelvis != null && lSholder != null
                && rSholder != null && lElbow != null && rElbow != null && lWrist != null
                && rWrist != null && lThigh != null && rThigh != null && lKnee != null
                && rKnee != null && lAnkle != null && rAnkle != null)
            {

               // _graphics.DrawCircle(_white, new Circle(head.X, head.Y, w / 6), 1);
                _graphics.DrawLine(_white, new Line(neck.X, neck.Y, chest.X, chest.Y), 1);
                _graphics.DrawLine(_white, new Line(chest.X, chest.Y, pelvis.X, pelvis.Y), 1);

                _graphics.DrawLine(_white, new Line(chest.X, chest.Y, lSholder.X, lSholder.Y), 1);
                _graphics.DrawLine(_white, new Line(chest.X, chest.Y, rSholder.X, rSholder.Y), 1);

                _graphics.DrawLine(_white, new Line(lSholder.X, lSholder.Y, lElbow.X, lElbow.Y), 1);
                _graphics.DrawLine(_white, new Line(rSholder.X, rSholder.Y, rElbow.X, rElbow.Y), 1);

                _graphics.DrawLine(_white, new Line(lElbow.X, lElbow.Y, lWrist.X, lWrist.Y), 1);
                _graphics.DrawLine(_white, new Line(rElbow.X, rElbow.Y, rWrist.X, rWrist.Y), 1);

                _graphics.DrawLine(_white, new Line(pelvis.X, pelvis.Y, lThigh.X, lThigh.Y), 1);
                _graphics.DrawLine(_white, new Line(pelvis.X, pelvis.Y, rThigh.X, rThigh.Y), 1);

                _graphics.DrawLine(_white, new Line(lThigh.X, lThigh.Y, lKnee.X, lKnee.Y), 1);
                _graphics.DrawLine(_white, new Line(rThigh.X, rThigh.Y, rKnee.X, rKnee.Y), 1);

                _graphics.DrawLine(_white, new Line(lKnee.X, lKnee.Y, lAnkle.X, lAnkle.Y), 1);
                _graphics.DrawLine(_white, new Line(rKnee.X, rKnee.Y, rAnkle.X, rAnkle.Y), 1);

            }
        }


        private void DrawShadowText(Graphics gfx, Font font, IBrush brush, Point pt, string txt)
        {
            var bpPt = new Point(pt.X - 1, pt.Y + 1);
            //var bpPt2 = new Point(pt.X + 1, pt.Y - 1);
            gfx.DrawText(font, _txtBrush, bpPt, txt);
            //gfx.DrawText(font, _txtBrush, bpPt2, txt);
            gfx.DrawText(font, brush, pt, txt);

        }
        private void DrawShadowText(Graphics gfx, Font font, float fontSize, IBrush brush, Point pt, string txt)
        {
            var bpPt = new Point();
            bpPt.X = pt.X - 1;
            bpPt.Y = pt.Y + 1;
            gfx.DrawText(font, fontSize, _txtBrush, bpPt, txt);
            gfx.DrawText(font, fontSize, brush, pt, txt);
        }

        private void DrawPlayerBlood(float x, float y, float h, float w, float fBlood)
        {
            if (fBlood > 70.0)
            {
                //FillRGB(x, y, 5, h, TextBlack);
                //FillRGB(x, y, 5, h * fBlood / 100.0, TextGreen);
                _graphics.FillRectangle(_black, Rectangle.Create(x, y, w, h));
                _graphics.FillRectangle(_green, Rectangle.Create(x, y, w, h * fBlood / 100));
            }
            if (fBlood > 30.0 && fBlood <= 70.0)
            {
                //FillRGB(x, y, 5, h, TextBlack);
                //FillRGB(x, y, 5, h * fBlood / 100.0, TextYellow);
                _graphics.FillRectangle(_black, Rectangle.Create(x, y, w, h));
                _graphics.FillRectangle(_yellow, Rectangle.Create(x, y, w, h * fBlood / 100));
            }
            if (fBlood > 0.0 && fBlood <= 30.0)
            {
                //FillRGB(x, y, 5, h, TextBlack);
                //FillRGB(x, y, 5, h * fBlood / 100.0, TextRed);
                _graphics.FillRectangle(_black, Rectangle.Create(x, y, w, h));
                _graphics.FillRectangle(_red, Rectangle.Create(x, y, w, h * fBlood / 100));
            }
        }

        private void _window_SizeChanged(object sender, OverlaySizeEventArgs e)
        {
            if (_graphics == null) return;

            if (_graphics.IsInitialized)
            {
                _graphics.Resize(e.Width, e.Height);
            }
            else
            {
                _graphics.Width = e.Width;
                _graphics.Height = e.Height;
            }
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)] public SendInputEventType type;
        [FieldOffset(4)] public MouseInput mi;
        [FieldOffset(4)] public KeybdInput ki;
        [FieldOffset(4)] public HardwareInput hi;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }
    public enum SendInputEventType
    {
        InputMouse,
        InputKeyboard,
        InputHardware
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KeybdInput
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public MouseEventFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [Flags]
    public enum MouseEventFlags : uint
    {
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
        MOUSEEVENTF_ABSOLUTE = 0x8000
    }
}
