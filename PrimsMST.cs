using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje4
{
    using System;

    class MST
    {
        //graphteki düğüm sayısı
        static int V = 7;

        //mstye eklenmemiş tepeler arasından min uzaklığa sahip olanı seçen fonksiyon
        static int minKey(int[] key, bool[] mstSet)
        {
            // Minimum değeri başlat
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        //oluşturulan mstyi yazdıran metot
        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Kenar \tAğırlık");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        }

        //adjanency matirisi kullanarak mst hesaplayan metot
        static void primMST(int[,] graph)
        {
            //mstnin tutulduğu dizi. gidilen her düğümden önceki düğümü tutar
            int[] parent = new int[V];

            //min ağırlıklı kenarı bulmak için kullanılan keyleri tutan array
            //key değerleri graphtaki ağırlık anlamına geliyor.
            int[] key = new int[V];

            //mstye dahil olan tepe bilgisini true false olarak tutan array
            bool[] mstSet = new bool[V];

            //tüm ağırlıklar sonsuz olarak başlatılıyor.
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            //1.düğüm başlangıc düğümü olarak seçiliyor. minKey metodunun başta seçebilmesi için key değeri 0a eşitleniyor.
            key[0] = 0;
            parent[0] = -1;

            //mstde toplam v tane tepe olacak ilki seçildiği için bu döngü v-1 kere çalışacak
            for (int count = 0; count < V - 1; count++)
            {
                //gidilmemiş tepelerden minağırlığa sahip olan seçiliyor.
                int u = minKey(key, mstSet);

                //seçilen tepe mstye eklendi
                mstSet[u] = true;

                //seçili tepeniin komsusu olan ve henüz mstye eklenmemiş tepelerin key ve parentlarını güncelliyor.
                for (int v = 0; v < V; v++)
                    // bu for döngüsü seçilen kenar ile bulunan bütüne kenarlar arasında
                    //önce komsuluk olup olmadığını (aralarındaki mesafe 0 ise bağlantıları yoktur)
                    //sonra kontrol edilen kenarın mstde olup olmadığını
                    //en son ise seçilen tepe ile kontrol edilen tepe arasındaki uzaklık kontrol ediliyor eğer şu anda
                    //tespit edilmiş en küçük uzaklık ise if bloğu çalışıyor ve key arrayi güncelleniyor ve iki tepe arası uzaklık giriliyor
                    //ayrıca üzerinde bulunulan tepeye parent olarak u(seçilen) tepesi atanıyor.
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            //olusturulan mst yazdırılıyor.
            printMST(parent, graph);
        }

        //kodun test edildiği kısım
        /*public static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 28,0,0,0,0,10,0},
                                    { 28,0,16,0,0,0,14 },
                                    { 0,16,0,12,0,0,0},
                                    { 0,0,12,0,22,0,18},
                                    { 0,0,0,22,0,25,24},
                                    { 10,0,0,0,25,0,0},
                                    {0,14,0,18,24,0,0 } };

            primMST(graph);
        }*/
    }
}
