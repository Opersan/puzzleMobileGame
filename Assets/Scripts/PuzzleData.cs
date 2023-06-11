using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleStoryEasyData : MonoBehaviour
{
    public static List<PuzzleData.PuzzleStoryData> getData()
    {
        List<PuzzleData.PuzzleStoryData> data = new List<PuzzleData.PuzzleStoryData>();
        string sehir1 = "�stanbul'dan ";
        string sehir2 = "Ankara'ya ";
        string sehir3 = "Arifiye'de ";
        string sehir4 = "Eski�ehir'de ";
        int sayi1 = 88;
        int sayi2 = 12;
        int sayi3 = 45;
        int sayi4 = 12;
        int sayi5 = 120;
        int cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        Color renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(0, "Bir tren " +  sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " + 
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " + 
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " + 
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 + 
            "trenden ka� ki�i inmi�tir?", cevap, "a", renk));
        sehir1 = "Elaz��'dan ";
        sehir2 = "Malatya'ya ";
        sehir3 = "S�rs�r�'de ";
        sehir4 = "Hekimhan'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(1, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "b", renk));
        sehir1 = "Malatya'dan ";
        sehir2 = "Elaz��'ya ";
        sehir3 = "Hekimhan'da ";
        sehir4 = "S�rs�r�'de ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(2, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "c", renk));
        sehir1 = "Giresun'dan ";
        sehir2 = "Ankara'ya ";
        sehir3 = "Bulancak'da ";
        sehir4 = "Ordu'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(3, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "d", renk));
        sehir1 = "Marmaris'den ";
        sehir2 = "Mu�la'ya ";
        sehir3 = "Ku�adas�'nda ";
        sehir4 = "�l�e'de ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(4, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "e", renk));
        sehir1 = "Antalya'dan ";
        sehir2 = "Ankara'ya ";
        sehir3 = "Konya'da ";
        sehir4 = "Antakya'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(5, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "f", renk));
        sehir1 = "Kastamonu'dan ";
        sehir2 = "K�r�kkale'ye ";
        sehir3 = "Konya'da ";
        sehir4 = "Sinop'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(6, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "d", renk));
        sehir1 = "K�r�kkale'den ";
        sehir2 = "Giresun'na ";
        sehir3 = "Bulancak'da ";
        sehir4 = "Ordu'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(7, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "f", renk));
        sehir1 = "Ordu'dan ";
        sehir2 = "Hataya'ya ";
        sehir3 = "Elaz��'da ";
        sehir4 = "Sivas'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(8, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "a", renk));
        sehir1 = "Hatay'dan ";
        sehir2 = "Tekirda�'ya ";
        sehir3 = "�skenderun'da ";
        sehir4 = "Ankara'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(9, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "b", renk));
        sehir1 = "Tekirda�'dan ";
        sehir2 = "Erzurum'a ";
        sehir3 = "Ankara'da ";
        sehir4 = "�stanbul'da ";
        sayi1 = 88;
        sayi2 = 12;
        sayi3 = 45;
        sayi4 = 12;
        sayi5 = 120;
        cevap = (sayi1 + sayi2 + sayi3) - sayi2 - sayi5;
        renk = Color.black;
        data.Add(new PuzzleData.PuzzleStoryData(10, "Bir tren " + sehir1 +
            sehir2 + "gidiyor. Yolda " + sehir3 + "ve " + sehir4 + "duruyor. " +
            sehir1 + "hareket ederken trende " + sayi1 + " yolcu vard�. " + "Arifiye" + "'de baz� yolcular " +
            "trenden indi, " + sayi2 + " yolcu trene bindi. " + sehir4 + sayi3 + " ki�i daha trene bindi, " +
            sayi4 + " ki�i trenden indi. Tren " + "Ankara" + "'ya vard���nda, i�inde " + sayi5 + " yolcu oldu�unda g�re " + sehir3 +
            "trenden ka� ki�i inmi�tir?", cevap, "c", renk));


        return data;
    }
}

public class PuzzleData : MonoBehaviour
{

    public static PuzzleData ins;

    public struct PuzzleStoryData
    {
        public int storyID;
        public string story;
        public int answer;
        public string storyBackgroundImage;
        public Color color;

        public PuzzleStoryData(int storyID, string story, int answer, string storyBackgroundImage, Color color) : this()
        {
            this.storyID = storyID;
            this.story = story;
            this.answer = answer;
            this.storyBackgroundImage = storyBackgroundImage;
            this.color = color;
        }
    };


    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(ins);
        }
    }
    

    public List<PuzzleStoryData> puzzleStory_data = new List<PuzzleStoryData>();
    // Start is called before the first frame update
    void Start()
    {
        puzzleStory_data = PuzzleStoryEasyData.getData();
    }

}

