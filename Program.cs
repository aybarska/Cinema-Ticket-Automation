using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using sqldeneme1.Properties;

namespace sqldeneme1
{
    static class Program
    {
       
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            
        }
    }
           class Koltuk: System.Windows.Forms.Button
        {
            public Koltuk()
            {
                Width = 27;
                Height = 30;
                FlatStyle = FlatStyle.Flat;
                Text = " ";
                

            }


            public int Numara { get; set; }

            private KoltukDurum koltukdurum;

            public KoltukDurum KoltukDurum
            {
                get { return koltukdurum; }
                set
                {
                    switch (value)
                    {
                    case KoltukDurum.Bos:
                        BackgroundImage = Resources.koltuk28;
                        break;
                    case KoltukDurum.Satildi:
                        BackgroundImage = Resources.koltuk28black;
                        break;
                }
               koltukdurum = value;
                   
            }
            }


        }

    enum KoltukDurum
    {
        Bos,
        Satildi,
    }
}
