using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    PdfAyar pdf = new PdfAyar();
    protected void Page_Load(object sender, EventArgs e)
    {
        PdfFormOlustur();
    }

    void PdfFormOlustur(string gosterim = "e")
    {
        //PDF OLUŞTURMA İŞLEMLERİ
        Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());// A4.Rotate()
        MemoryStream output = new MemoryStream();
        pdf.PDFDosyaBasi(doc, output, tM: 10, lM: 40, rM: 40);

        //select * from kurumsalbilggi

        pdf.yeniparagraf(doc, fontboyut: 5);
        pdf.yeniparagraf(doc, "T.C.", hiza: "C", fontboyut: 10, fonttip: "B");
        pdf.yeniparagraf(doc, "MİLLİ EĞİTİM BAKANLIĞI", hiza: "C", fontboyut: 10, fonttip: "B");
        pdf.yeniparagraf(doc, "Ölçme,Değerlendirme ve Sınav Hizmetleri Genel Müdürlüğü", hiza: "C", fontboyut: 10, fonttip: "B");
        pdf.yeniparagraf(doc, "Ölçme,Değerlendirme ve Yerleştirme Hizmetleri Daire Başkanlığı", hiza: "C", fontboyut: 10, fonttip: "B");
        pdf.yeniparagraf(doc, "Masa Ekibi Tespit Tutanağı", hiza: "C", fontboyut: 10, fonttip: "B");
        pdf.yeniparagraf(doc, fontboyut: 20);


        Tablo1Olustur(doc);
        pdf.yeniparagraf(doc, " Bu Başlık Kısmının Altına 2.Tablo Gelecektir.", hiza: "C", fontboyut: 10, fonttip: "B");
        pdf.yeniparagraf(doc, fontboyut: 5);

        doc.Add(Tablo2(doc));
        doc.Close();


        pdf.PDFDosyaSonu(output, dosyaadi: "PdfDosya", gosterimsekli: gosterim);

    }
    void Tablo1Olustur(Document doc)
    {
        PdfPTable tablo = new PdfPTable(2);
        int[] genislik = new int[] { 1, 1 };
        pdf.PDFTableOlustur(doc, tablo, genislik, ToplamGenislik: 520);
        //  Hücre Sol Kısım
        PdfPCell yenisatir = new PdfPCell(new Phrase("sol tablo buraya gelecek "));
        yenisatir.FixedHeight = 130;
        yenisatir.Border = 0;
        yenisatir.AddElement(Tablo1A(doc));
        tablo.AddCell(yenisatir);

        //Hücre Sağ Kısım
        PdfPCell yenisatir2 = new PdfPCell(new Phrase("sağ tablo buraya gelecek "));
        yenisatir2.FixedHeight = 130;
        yenisatir2.Border = 0;
        yenisatir2.AddElement(Tablo1B(doc));
        tablo.AddCell(yenisatir2);


        doc.Add(tablo);
        pdf.yeniparagraf(doc, fontboyut: 2);
    }
    PdfPTable Tablo1A(Document doc)
    {
        PdfPTable tabloA = new PdfPTable(3);
        int[] genislika = new int[] { 3, 1, 10 };
        pdf.PDFTableOlustur(doc, tabloA, genislika, ToplamGenislik: 250);
        for (int i = 1; i <= 10; i++)
        {
            pdf.hucreEkle(tabloA, i + ". Satır", satiryukseklik: 12, metinhiza: "C", fontboyut: 7, kutu: i == 1 ? "U1" : "O1");
            pdf.hucreEkle(tabloA, ":", satiryukseklik: 12, metinhiza: "C", fontboyut: 7, kutu: i == 1 ? "U" : "O");
            pdf.hucreEkle(tabloA, i + ". Satır İçerik", satiryukseklik: 12, metinhiza: "L", fontboyut: 7, kutu: i == 1 ? "U" : "O");
        }
        return tabloA;
    }
    PdfPTable Tablo1B(Document doc)
    {
        PdfPTable tabloA = new PdfPTable(3);
        int[] genislika = new int[] { 3, 1, 10 };
        pdf.PDFTableOlustur(doc, tabloA, genislika, ToplamGenislik: 250);
        for (int i = 1; i <= 10; i++)
        {
            pdf.hucreEkle(tabloA, i + ". Satır", satiryukseklik: 12, metinhiza: "C", fontboyut: 7);
            pdf.hucreEkle(tabloA, ":", satiryukseklik: 12, metinhiza: "C", fontboyut: 7);
            pdf.hucreEkle(tabloA, i + ". Satır İçerik", satiryukseklik: 12, metinhiza: "L", fontboyut: 7);
        }
        return tabloA;
    }


    PdfPTable Tablo2(Document doc)
    {
        PdfPTable tabloA = new PdfPTable(10);
        int[] genislika = new int[] { 2, 2, 3, 3, 4, 4, 3, 3, 2, 2 };
        pdf.PDFTableOlustur(doc, tabloA, genislika, ToplamGenislik: 510);
        for (int x = 1; x <= 1; x++)
        {
            for (int y = 1; y <= 10; y++)
            {
                if (x == 1)
                    pdf.hucreEkle(tabloA, x + "-" + y, satiryukseklik: 12, metinhiza: "C", fontboyut: 7, kutu: y == 1 ? "U1" : "U");
                else
                    pdf.hucreEkle(tabloA, x + "-" + y, satiryukseklik: 12, metinhiza: "C", fontboyut: 7, kutu: y == 1 ? "O1" : "O");
            }


        }
        return tabloA;
    }
}