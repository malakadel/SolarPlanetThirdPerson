
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTKTut.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;


namespace OpenTKTut
{


   
    
    partial class Viewport : Program
    {
        
            Shapes.Sphere Sun = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 5, true,false,false, 1, 0, 0, 0,  0, 1); 
            Shapes.Sphere earth = new Shapes.Sphere(new Vector3( 0.0f,0.0f,43.0f), 1.3, true, true, false, 3, 15, 1.1f, 0, 0, 4);
            Shapes.Sphere mercury = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), .488, true,true,false, 1, 6, 1.5f, 0, 0, 2);          
            Shapes.Sphere venus = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 1, true, true, false, 2, 11, 1.3f, 0, 0, 3); 
            Shapes.Sphere moon_earth = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 0.7, true, true, true, 1, 15, 1.1f, 1.5f, 2f, 5);     
            Shapes.Sphere mars = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 0.88, true, true, false, 1, 23, .9f, 0, 0, 6); 
            Shapes.Sphere mars_moon = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 0.4f, true, true, true, 1, 23, .9f, 1f, 2f, 5);    
            Shapes.Sphere jupiter = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 2.5, true, true, false, 1, 30, .6f, 0, 0, 7); 
            Shapes.Sphere uranus = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f),1.5, true, true, false, 1, 40, .3f, 0, 0, 9); 
            Shapes.Sphere neptune = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 1.3, true, true, false, 1, 45, .2f, 0, 0, 10); 
            Shapes.Sphere saturn = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 2, true, true, false, 1, 35, .5f, 0, 0, 8); 
            Shapes.Sphere PLUOT = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), 2, true, true, false, 1, 50, .4f, 0, 0, 12);
            Shapes.Sphere rocket = new Shapes.Sphere(new Vector3(0 , 0 , 5),0.5f,false,false,false,0,0,0,0,0,11);
            //Shapes.Sphere rocket2 = new Shapes.Sphere(new Vector3(0, 0, 15), .5f, false, false, false, 0, 0, 0, 0, 0, 11);


        private List<OGLShape> _drawList;

        public Key _keyPressed;
        int  texture1, texture2, texture3, texture4, texture5, texture6, texture7, texture8, texture9, texture10, texture11,texture12,texture13;

        private void InitializeObjects()
        {
               _drawList = new List<OGLShape>();
               _drawList.Add(rocket);
               _drawList.Add(earth);
               _drawList.Add(Sun);
               _drawList.Add(mercury);
               _drawList.Add(venus);
               _drawList.Add(moon_earth);
               _drawList.Add(mars);
               _drawList.Add(mars_moon);
               _drawList.Add(jupiter);
               _drawList.Add(uranus);
               _drawList.Add(neptune);
               _drawList.Add(saturn);
               _drawList.Add(PLUOT);
        }
        
        private void SetEvents()
        {
               
            _window.RenderFrame += _window_RenderFrame;
            _window.Resize += _window_Resize;
            _window.Load += _window_Load;
            _window.KeyDown += _window_KeyDown;
            _window.UpdateFrame += _window_UpdateFrame;
                              
        }

        private void _window_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

                      
            
            //Textures
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1, out texture1);
            GL.GenTextures(1, out texture2);
            GL.GenTextures(1, out texture3);
            GL.GenTextures(1, out texture4);
            GL.GenTextures(1, out texture5);
            GL.GenTextures(1, out texture6);
            GL.GenTextures(1, out texture7);
            GL.GenTextures(1, out texture8);
            GL.GenTextures(1, out texture9);
            GL.GenTextures(1, out texture10);
            GL.GenTextures(1, out texture11);
            GL.GenTextures(1, out texture12);
            GL.GenTextures(1, out texture13);


            GL.BindTexture(TextureTarget.Texture2D, 1);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData1.Width, texData1.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData1.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 2);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData2.Width, texData2.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData2.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData3.Width, texData3.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData3.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 4);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData4.Width, texData4.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData4.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 5);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData5.Width, texData5.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData5.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 6);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData6.Width, texData6.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData6.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 7);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData7.Width, texData7.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData7.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 8);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData8.Width, texData8.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData8.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 9);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData9.Width, texData9.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData9.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 10);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData10.Width, texData10.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData10.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 11);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData11.Width, texData11.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData11.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            
            GL.BindTexture(TextureTarget.Texture2D, 12);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData12.Width, texData12.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData12.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);


            GL.BindTexture(TextureTarget.Texture2D, 13);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData13.Width, texData13.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData13.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

        }

        private void _window_Resize(object sender, EventArgs e)
        {
            if (_window.Height != 0)
            { 
                GL.Viewport(0, 0, _window.Width, _window.Height);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();         
                Matrix4 prespective = Matrix4.CreatePerspectiveFieldOfView(45f * 3.14f / 180.0f, _window.Width / _window.Height, 0.10f, 150.0f);             
                GL.LoadMatrix(ref prespective);
                GL.MatrixMode(MatrixMode.Modelview);
                MoveModelDown(7);
                MoveTheModeltome(18);
                RotateModelDown(10);
               
            }
        }

        private void _window_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            
            if (((earth._Center.Z-1.3f) <=rocket._Center.Z && rocket._Center.Z <= (earth._Center.Z+ 1.3f)) &&
                ((earth._Center.Y-1.3f) <=rocket._Center.Y && rocket._Center.Y <=(earth._Center.Y+1.3f))&&
                ((earth._Center.X-1.3f) <=rocket._Center.X && rocket._Center.X <=(earth._Center.X+1.3f)))
            {

                MessageBox.Show("Game Over, you crashed with Earth !", "Message");
                System.Environment.Exit(0);     
            }
            if (((mercury._Center.Z-.488f) <=rocket._Center.Z && rocket._Center.Z <= (mercury._Center.Z+.488f)) &&
                ((mercury._Center.Y-.488f) <=rocket._Center.Y && rocket._Center.Y <=(mercury._Center.Y+.488f))&&
                ((mercury._Center.X-.488f) <=rocket._Center.X && rocket._Center.X <=(mercury._Center.X+.488f)))
            {
                MessageBox.Show("Game over, you crashed with Mercury !", "Message");

                System.Environment.Exit(0);     
            }
            if (((venus._Center.Z-1) <=rocket._Center.Z && rocket._Center.Z <= (venus._Center.Z+1)) &&
                ((venus._Center.Y-1) <=rocket._Center.Y && rocket._Center.Y <=(venus._Center.Y+1))&&
                ((venus._Center.X-1) <=rocket._Center.X && rocket._Center.X <=(venus._Center.X+1)))
            {
                MessageBox.Show("Game over, you crashed with Venus !", "Message");

                System.Environment.Exit(0);     
            }
            if (((mars._Center.Z-0.88) <=rocket._Center.Z && rocket._Center.Z <= (mars._Center.Z+0.88)) &&
                ((mars._Center.Y-0.88) <=rocket._Center.Y && rocket._Center.Y <=(mars._Center.Y+0.88))&&
                ((mars._Center.X-0.88) <=rocket._Center.X && rocket._Center.X <=(mars._Center.X+0.88)))
            {
                MessageBox.Show("Game over, you crashed with Mars !", "Message");

                System.Environment.Exit(0);     
            }
            if (((jupiter._Center.Z-2.5) <=rocket._Center.Z && rocket._Center.Z <= (jupiter._Center.Z+2.5)) &&
                ((jupiter._Center.Y-2.5) <=rocket._Center.Y && rocket._Center.Y <=(jupiter._Center.Y+2.5))&&
                ((jupiter._Center.X-2.5) <=rocket._Center.X && rocket._Center.X <=(jupiter._Center.X+2.5)))
            {
                MessageBox.Show("Game over, you crashed with Jupiter !", "Message");
                System.Environment.Exit(0);     
            }
            if (((uranus._Center.Z-1.5) <=rocket._Center.Z && rocket._Center.Z <= (uranus._Center.Z+1.5)) &&
                ((uranus._Center.Y-1.5) <=rocket._Center.Y && rocket._Center.Y <=(uranus._Center.Y+1.5))&&
                ((uranus._Center.X-1.5) <=rocket._Center.X && rocket._Center.X <=(uranus._Center.X+1.5)))
            {
                MessageBox.Show("Game over, you crashed with Uranus !", "Message");
                System.Environment.Exit(0);     
            }

            if (((neptune._Center.Z-1.3) <=rocket._Center.Z && rocket._Center.Z <= (neptune._Center.Z+1.3)) &&
                ((neptune._Center.Y-1.3) <=rocket._Center.Y && rocket._Center.Y <=(neptune._Center.Y+1.3))&&
                ((neptune._Center.X-1.3) <=rocket._Center.X && rocket._Center.X <=(neptune._Center.X+1.3)))
            {
                MessageBox.Show("Game over, you crashed with Neptune !", "Message");
                System.Environment.Exit(0);     
            }

            if (((saturn._Center.Z-2) <=rocket._Center.Z && rocket._Center.Z <= (saturn._Center.Z+2)) &&
                ((saturn._Center.Y-2) <=rocket._Center.Y && rocket._Center.Y <=(saturn._Center.Y+2))&&
                ((saturn._Center.X-2) <=rocket._Center.X && rocket._Center.X <=(saturn._Center.X+2)))
            {
                MessageBox.Show("Game over, you crashed with Saturn !", "Message");
                System.Environment.Exit(0);     
            }

            if (((PLUOT._Center.Z-2) <=rocket._Center.Z && rocket._Center.Z <= (PLUOT._Center.Z+2)) &&
                ((PLUOT._Center.Y-2) <=rocket._Center.Y && rocket._Center.Y <=(PLUOT._Center.Y+2))&&
                ((PLUOT._Center.X-2) <=rocket._Center.X && rocket._Center.X <=(PLUOT._Center.X+2)))
            {
                MessageBox.Show("Game over, you crashed with Plout !", "Message");
                System.Environment.Exit(0);     
            }

         
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Draw Stars
            GL.PointSize(3);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.87f, .58f , 0.98f);

            foreach (var item in starposition)
            {
                GL.Vertex3(item.X, item.Y, item.Z);
            }
            GL.End();


            for (int i=0;i<_drawList.Count;i++)
            {
                _drawList[i].Draw();
            }

            _window.SwapBuffers();
        }

        private void _window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            
            _keyPressed = e.Key;
        }


        private void _window_UpdateFrame(object sender, FrameEventArgs e)
        {



            switch (_keyPressed)
            {
                case Key.Right:
                    rocket._Center = rocket._Center + new Vector3(1,0,0);
                    MoveModelLeft(1);


                   if ((38 <=rocket._Center.Z && rocket._Center.Z <=48) && (-5 <=rocket._Center.X && rocket._Center.X <=5) && (-5 <=rocket._Center.Y && rocket._Center.Y <=5)  )
                    {   
                      rocket._Center = rocket._Center + new Vector3(-1,0,0);
                      MoveModelLeft(-1);  
                    }                            
                    break;




                case Key.Left:
                    rocket._Center = rocket._Center + new Vector3(-1,0,0);
                    MoveModelRight(1);

                    if ((38 <=rocket._Center.Z && rocket._Center.Z <=48) && (-5 <=rocket._Center.X && rocket._Center.X <=5) && (-5 <=rocket._Center.Y && rocket._Center.Y <=5)  )
                        {   
                          rocket._Center = rocket._Center + new Vector3(1,0,0);                           
                           MoveModelRight(-1);   
                        }       
                    break;


                case Key.Down:
                        rocket._Center = rocket._Center + new Vector3(0,0,-1);
                        MoveTheModeltome(1);


                    if ((38 <=rocket._Center.Z && rocket._Center.Z <=48) && (-5 <=rocket._Center.X && rocket._Center.X <=5) && (-5 <=rocket._Center.Y && rocket._Center.Y <=5)  )
                    {   
                      rocket._Center = rocket._Center + new Vector3(0,0,1);                           
                      MoveTheModeltome(-1);
                      
                    }

                    break;


                case Key.Up:
                     rocket._Center = rocket._Center + new Vector3(0,0,1);
                     MoveTheModelAway(1);

                     if ((38 <=rocket._Center.Z && rocket._Center.Z <=48) && (-5 <=rocket._Center.X && rocket._Center.X <=5) && (-5 <=rocket._Center.Y && rocket._Center.Y <=5)  )
                        {   
                          rocket._Center = rocket._Center + new Vector3(0,0,-1);                           
                          MoveTheModelAway(-1);    
                        }

                    break;



                case Key.W:
                        MoveModelDown(1);
                        rocket._Center = rocket._Center + new Vector3(0,1,0);


                       if ((38 <=rocket._Center.Z && rocket._Center.Z <=48) && (-5 <=rocket._Center.X && rocket._Center.X <=5) && (-5 <=rocket._Center.Y && rocket._Center.Y <=5)  )
                         {   
                              rocket._Center = rocket._Center + new Vector3(0,-1,0);                           
                              MoveModelDown(-1);;   
                           
                          }
                    break;


                case Key.S:
                        MoveModelUp(1);
                        rocket._Center = rocket._Center + new Vector3(0,-1,0);
                        if ((38 <=rocket._Center.Z && rocket._Center.Z <=48) && (-5 <=rocket._Center.X && rocket._Center.X <=5) && (-5 <=rocket._Center.Y && rocket._Center.Y <=5)  )
                         {   
                              rocket._Center = rocket._Center + new Vector3(0,1,0);                           
                              MoveModelUp(-1);
                                  
                          }                
                    break;




                case Key.A:
                    RotateModelRight(1);
                    break;
                case Key.D:
                    RotateModelLeft(1);
                    break;
                case Key.ControlLeft:
                    RotateModelDown(1);
                    break;
                case Key.ControlRight:
                    RotateModelUp(1);
                    break;
               

            }
        }

        public void RotateModelRight(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, -Vector3.UnitY);
           
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RotateModelLeft(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RotateModelUp(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, -Vector3.UnitX);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void RotateModelDown(float v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Rotate(v, Vector3.UnitX);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveTheModelAway(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(Vector3.UnitZ * v);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveTheModeltome(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(-Vector3.UnitZ * v);
            
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveModelRight(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(Vector3.UnitX * v);
           
            GL.MatrixMode(MatrixMode.Modelview);
       



        }

        public void MoveModelLeft(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(-Vector3.UnitX * v);
           
            GL.MatrixMode(MatrixMode.Modelview);
        }


        public void MoveModelUp(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(Vector3.UnitY * v);
            
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void MoveModelDown(int v)
        {
            _keyPressed = Key.Clear;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Translate(-Vector3.UnitY * v);          
            GL.MatrixMode(MatrixMode.Modelview);
        }



        
    
    }
}
