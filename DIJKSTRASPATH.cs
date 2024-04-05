using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje4
{
    internal class DIJKSTRASPATH
    {
        // bu classın amacı dijkstranın en kısa yol algoritması ile
        //verlien çizgenin en kısa yolunu bulmaktır.
        static int TepeSay = 6;

        int minUzaklık(int[] uzaklıklar, bool[] tepeArray)
        {
            //bu metot tepeleri içeren listede gezerek gidilmemiş olanlardan
            //en yakın olanını seçip index değerini döndürüyor.
            int min = int.MaxValue;
            int min_index = -1;

            for (int i = 0; i < TepeSay; i++)
            {
                if (tepeArray[i] == false && uzaklıklar[i] <= min)
                {
                    min = uzaklıklar[i];
                    min_index = i;
                }
            }

            return min_index;
        }

        void sonucArrayYazdır(int[] uzaklıklar)
        {
            //olusan sonuc arrayini yazdıran metot
            Console.WriteLine("Tepe numarası\tMesafe");
            for (int i = 0; i < TepeSay; i++)
            {
                Console.WriteLine(i + "\t\t  " + uzaklıklar[i]);
            }
        }

        public void dijkstraYolu(int[,] graph, int kaynakTepeIndex)
        {
            //mesafe matrisini ve kaynak köşeyi kullanarak uzaklık hesabı yapacak olan metot
            int[] uzaklıklar = new int[TepeSay];//uzaklıkların tutulacağı array
            bool[] tepeArray = new bool[TepeSay]; //tepelerin gezilip gezilmediği bilgisini tutacak olan array

            for (int i = 0; i < TepeSay; i++)
            {
                //burada bütün uzaklık değerlerini max'a eşitleyip
                //tepelerin gezlime bilgisini falsea eşitledim.
                uzaklıklar[i] = int.MaxValue;
                tepeArray[i] = false;
            }

            uzaklıklar[kaynakTepeIndex] = 0;//kaynak tepenin mesafe 0 olarak atanıyor
            //cunku buradan baslanılacak.

            for (int count = 0; count < TepeSay - 1; count++)
            {
                //tepeler arasından henüz gezilmemiş ve min uzaklığa
                //sahip olan tepeyi seçiyoruz
                int u = minUzaklık(uzaklıklar, tepeArray);

                //seçilen tepeyi gezilmiş olarak işaretledik
                tepeArray[u] = true;

                //uzaklık bilgisini güncelliyoruz.
                for (int v = 0; v < TepeSay; v++)
                {
                    //eğer v tepesi gezilmemişse ve u tepesinden v tepesine
                    // giden yol varsa ve baslangıctan vye toplam uzunluktan kısaysa v uzaklığı güncelleniyor.
                    if (!tepeArray[v] && graph[u, v] != 0 && uzaklıklar[u] != int.MaxValue && (uzaklıklar[u] + graph[u, v]) < uzaklıklar[v])
                    {
                        uzaklıklar[v] = uzaklıklar[u] + graph[u, v];
                    }
                }
            }
            sonucArrayYazdır(uzaklıklar);
        }
        /*
        public static void Main(string[] args)
        {
            int[,] cizge = { { 0, 2, 4, 0, 0, 0},
                { 0, 0, 1, 7, 0, 0},
                { 0, 0, 0, 0, 3, 0},
                { 0, 0, 0, 0, 0, 1},
                { 0, 0, 0, 2, 0, 5},
                { 0, 0, 0, 0, 0, 0}};

            DIJKSTRASPATH path = new DIJKSTRASPATH();
            path.dijkstraYolu(cizge, 0);
        }*/

    }
}
