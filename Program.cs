// See https://aka.ms/new-console-template for more information
using DataStructuresProje4;
using System;
using System.Collections.Generic;

class Program
{
    internal class Vertex
    {
        public char harf; //çizgede bulunan tepenin harf adı
        public bool gezildiMi; //tepe ziyaret edildi mi bilgisini boolean tutan değişken

        public Vertex(char lab)//constructor metot
        {
            harf = lab;
            gezildiMi = false;
        }
    }

    internal class Graph
    {
        private const int MAX_TEPE_SAY = 20;
        private Vertex[] tepeListesi;
        private int[,] komsulukMatrisi;
        private int tepeSay;
        private Queue<int> queue;//bfsde kullanılacak queue

        public Graph()//cosntructor
        {
            tepeListesi = new Vertex[MAX_TEPE_SAY];
            komsulukMatrisi = new int[MAX_TEPE_SAY, MAX_TEPE_SAY];
            tepeSay = 0;

            //komsuluk matrisini default olusturma
            for (int j = 0; j < MAX_TEPE_SAY; j++)
                for (int k = 0; k < MAX_TEPE_SAY; k++)
                    komsulukMatrisi[j, k] = 0;

            queue = new Queue<int>(); //queue olusturuldu
        }

        public void addVertex(char lab)
        {
            tepeListesi[tepeSay++] = new Vertex(lab);
        }

        public void addEdge(int start, int end)
        {
            komsulukMatrisi[start, end] = 1;
            komsulukMatrisi[end, start] = 1;
        }

        public void displayVertex(int v)//tepeyi yazdırıyo.
        {
            Console.Write(tepeListesi[v].harf);
        }

        public void bfs()//bfs aramasının yapıldığı kısım.
        {
            tepeListesi[0].gezildiMi = true; //baslangıc düğümü gezildi olarak isaretlerniyor.
            displayVertex(0);

            queue.Enqueue(0);//baslangıc dugumu kuyruga eklendi.

            while (queue.Count != 0)//arama kuyruk bosalana kadar devam edecek.
            {
                int v1 = queue.Dequeue(); //kuyrugun basındaki dugum cıkarıldı.

                int v2;
                while ((v2 = getAdjUnvisitedVertex(v1)) != -1) //ziyaret edilmemis komsu dugum bulana kadar devam edecn dongu
                {
                    tepeListesi[v2].gezildiMi = true; //ziyaret edildi olarak isaretlendi
                    displayVertex(v2);
                    queue.Enqueue(v2);//kuyruğa ekleme islemi
                }
            }

            //tüm düğümler ziyaret edildi olarak isaretlendi
            for (int j = 0; j < tepeSay; j++)
                tepeListesi[j].gezildiMi = false;
        }

        //ziyaret edilmemis komsu düğüm arayan metot
        public int getAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j < tepeSay; j++)
                if (komsulukMatrisi[v, j] == 1 && tepeListesi[j].gezildiMi == false)
                    return j;
            return -1;
        }
    }

    public static void Main()
    {
        Graph theGraph = new Graph();

        
        theGraph.addVertex('A');
        theGraph.addVertex('B');
        theGraph.addVertex('C');
        theGraph.addVertex('D');
        theGraph.addVertex('E');

        
        theGraph.addEdge(0, 1);
        theGraph.addEdge(1, 2);
        theGraph.addEdge(0, 3);
        theGraph.addEdge(3, 4);

        Console.Write("BFS gezinti: ");
        theGraph.bfs();
        Console.WriteLine();
    }
}


