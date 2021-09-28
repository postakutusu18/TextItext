using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    PdfAyar pdf = new PdfAyar();
    protected void Page_Load(object sender, EventArgs e)
    {
        PdfFormOlustur();
    }

    void PdfFormOlustur(string gosterim = "e")
    {
        //PDF OLUŞTURMA İŞLEMLERİ
        Document doc = new Document(iTextSharp.text.PageSize.A4);// A4.Rotate()
        MemoryStream output = new MemoryStream();
        pdf.PDFDosyaBasi(doc, output, tM: 10,lM:40,rM:40);

        //select * from kurumsalbilggi
        BelgeBilgi belgeBilgi = new BelgeBilgi();
        belgeBilgi.sinavAdi = "A Sınavı";
        belgeBilgi.sinavTarihi = "01.01.2021";
        belgeBilgi.dokumanKodu = "ÖDY/R0122/R.000";
        belgeBilgi.yayinTarihi = "11.11.2019";
        belgeBilgi.revTarihi = "-";
        belgeBilgi.revizeNo = "00";
        belgeBilgi.sayfaNo = "1/1";

        AciklamaBilgi aciklamaBilgi = new AciklamaBilgi();
        aciklamaBilgi.ilAdi = "Ankara";
        aciklamaBilgi.ilceAdi = "Gölbaşı";
        aciklamaBilgi.oturum = "1";
        aciklamaBilgi.salon = "2";
        aciklamaBilgi.binaAdi = "A Binası";

        aciklamaBilgi.icerik = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed gravida diam quis orci condimentum pharetra. Nullam laoreet nisl tristique turpis pellentesque, sed hendrerit dui ultrices. In nec purus dictum, efficitur quam ac, facilisis nunc. Etiam quis tincidunt nulla, id sagittis sapien. Proin quis velit arcu. Integer aliquam aliquam est eget laoreet. Vivamus pulvinar condimentum neque vel vestibulum. Phasellus vulputate vulputate diam, vitae maximus tortor maximus non. Integer bibendum, tortor a dignissim faucibus, sapien purus mattis turpis, vitae congue magna eros sed massa. Sed non euismod erat, id sollicitudin nunc. Duis lectus risus, auctor vel mollis non, consequat quis massa. Vivamus erat felis, lacinia ac mattis a, ullamcorper in est. Phasellus ante mauris, bibendum vel felis eu, suscipit scelerisque augue. Nunc vulputate laoreet ultrices. Phasellus luctus urna scelerisque felis vestibulum convallis.

Duis pharetra enim nec tortor scelerisque tempus. Phasellus id accumsan sem. Duis in felis tincidunt lacus venenatis mattis. Nam quis posuere neque. Nam aliquet dictum lectus id bibendum. Suspendisse facilisis velit mi. Praesent sed diam mi. Nullam lacus felis, pretium quis lorem in, euismod facilisis magna. Duis sed sapien vitae velit rhoncus laoreet. Sed ultricies ipsum eget augue pretium, et convallis orci rhoncus. Nullam turpis elit, cursus nec libero in, sodales auctor diam. Praesent sit amet sagittis nisi.

Morbi sem dolor, maximus sit amet mattis ut, dignissim ut lorem. Vivamus fermentum diam erat, at aliquam sapien auctor nec. Praesent vel mauris ac tellus efficitur laoreet. Praesent vel vestibulum eros. Aenean sed pharetra mauris. Etiam condimentum iaculis tellus sit amet viverra. Suspendisse tincidunt iaculis vulputate. Nam congue leo purus, sit amet tincidunt nulla vestibulum nec. Vestibulum mi nibh, porttitor id rhoncus quis, dictum quis purus. Fusce blandit eu enim eget rutrum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis id accumsan velit. Sed non egestas massa. Suspendisse nec nulla odio. Nullam bibendum porta hendrerit.

Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque porttitor nunc et libero rhoncus, a pulvinar mauris consequat. Aliquam sit amet enim maximus, hendrerit diam non, pharetra mauris. Proin et ex turpis. Donec accumsan diam congue mauris tristique, et tempor nisl volutpat. Phasellus molestie enim in varius sollicitudin. Nam sed auctor felis, cursus laoreet metus. Proin ut dui vulputate, venenatis enim id, sollicitudin metus. Aliquam cursus consequat dolor, at malesuada enim gravida sed. Sed vestibulum tortor nec ligula faucibus varius. Aliquam non mauris vel lacus ultricies scelerisque ut vel purus. Aenean consectetur ullamcorper diam non tincidunt. Donec venenatis sapien ut elit tempor iaculis. Etiam nec posuere nibh.

Donec euismod dui volutpat magna malesuada eleifend. Vivamus porta venenatis odio, et tincidunt purus lacinia id. Vestibulum varius, dolor eget blandit tristique, orci lacus varius justo, sit amet ultrices mauris metus in mi. Quisque sapien odio, sodales ut diam a, sodales bibendum mauris. Aenean ac augue gravida velit consectetur aliquam at vel elit. Suspendisse turpis mauris, finibus et vestibulum vel, vestibulum et nisl. Nam in euismod odio, sit amet malesuada sapien. Aenean elementum, sapien quis vestibulum ultrices, lorem erat feugiat ex, eu malesuada justo sapien nec diam.";

        ImzaBilgi imzaBilgi = new ImzaBilgi();
        imzaBilgi.masaNo = "1";
        imzaBilgi.tarih = "01.01.2020";
        imzaBilgi.saat = "08:00";
        imzaBilgi.ekipUyesi = "Üye A";
        imzaBilgi.ekipUyeUnvani = "A Ünvan";
        imzaBilgi.ekipBasi = "Baş B";
        imzaBilgi.ekipBasiUnvani = "B Ünvan";

   
        pdf.yeniparagraf(doc, fontboyut: 5);//BOŞLUK
        doc.Add(TabloBaslik(doc));
        doc.Add(TabloBelgeTarih(doc, belgeBilgi));
        pdf.yeniparagraf(doc, fontboyut: 5);//BOŞLUK
        pdf.yeniparagraf(doc, "Açıklama", hiza: "C", fontboyut: 14, fonttip: "B");
        pdf.yeniparagraf(doc, fontboyut: 5);//BOŞLUK


        doc.Add(TabloAciklama(doc, aciklamaBilgi));

        pdf.yeniparagraf(doc, fontboyut: 5);//BOŞLUK

        pdf.yeniparagraf(doc, "Tasnif işleminin yapıldığı :", hiza: "L", fonttip: "BU");
        pdf.yeniparagraf(doc, fontboyut: 10);//BOŞLUK
        doc.Add(TabloImza(doc,imzaBilgi));

        doc.Close();


        pdf.PDFDosyaSonu(output, dosyaadi: "PdfDosya", gosterimsekli: gosterim);

    }
    PdfPTable TabloBaslik(Document doc)
    {
        PdfPTable tablo = new PdfPTable(2);
        int[] genislika = new int[] { 1, 20 };
        pdf.PDFTableOlustur(doc, tablo, genislika, ToplamGenislik: 520);

        string imagepath = HttpContext.Current.Server.MapPath("/image");
        pdf.dresimekle(tablo, imagepath + "/meb-logo.png", 5f, PdfPCell.ALIGN_LEFT, 70, 70, 5);
        pdf.hucreEkle(tablo, "T.C.", metinhiza: "C", fonttip: "B");
        pdf.hucreEkle(tablo, "MİLLİ EĞİTİM BAKANLIĞI", metinhiza: "C", fonttip: "B");
        pdf.hucreEkle(tablo, "Ölçme,Değerlendirme ve Sınav Hizmetleri Genel Müdürlüğü", metinhiza: "C", fonttip: "B");
        pdf.hucreEkle(tablo, "Ölçme,Değerlendirme ve Yerleştirme Hizmetleri Daire Başkanlığı", metinhiza: "C", fonttip: "B");
        pdf.hucreEkle(tablo, "Masa Ekibi Tespit Tutanağı", metinhiza: "C",  fonttip: "B");

        

        return tablo;
    }
    PdfPTable TabloBelgeTarih(Document doc,BelgeBilgi belgeBilgi)
    {
        PdfPTable tablo = new PdfPTable(5);
        int[] genislika = new int[] {3,3,3,2,2 };
        pdf.PDFTableOlustur(doc, tablo, genislika, ToplamGenislik: 520);

      
        pdf.hucreEkle(tablo, "Doküman Kodu :",fonttip:"B",renk:5);
        pdf.hucreEkle(tablo, "Yayın Tarihi :", fonttip: "B", renk: 5);
        pdf.hucreEkle(tablo, "Rev. Tarihi :", fonttip: "B", renk: 5);
        pdf.hucreEkle(tablo, "Rev. No :", fonttip: "B", renk: 5);
        pdf.hucreEkle(tablo, "Sayfa :", fonttip: "B", renk: 5);


        pdf.hucreEkle(tablo, belgeBilgi.dokumanKodu, renk: 5);
        pdf.hucreEkle(tablo, belgeBilgi.yayinTarihi,  renk: 5);
        pdf.hucreEkle(tablo, belgeBilgi.revTarihi,  renk: 5);
        pdf.hucreEkle(tablo, belgeBilgi.revizeNo, renk: 5);
        pdf.hucreEkle(tablo, belgeBilgi.sayfaNo,  renk: 5);
        
        pdf.hucreEkle(tablo, "TUTANAKTIR ", metinhiza: "C", fontboyut: 14, fonttip: "B",kolonsayisi:5,satiryukseklik:22);
        pdf.hucreEkle(tablo, "Sınav Adı ve Tarihi : ", metinhiza: "L", fontboyut: 12, fonttip: "BU");
        pdf.hucreEkle(tablo, belgeBilgi.sinavAdi + " " + belgeBilgi.sinavTarihi, metinhiza: "L", fontboyut: 12, kolonsayisi: 4);






        return tablo;
    }

    PdfPTable TabloAciklama(Document doc,AciklamaBilgi aciklamaBilgi)
    {
        PdfPTable tablo = new PdfPTable(6);
        int[] genislika = new int[] { 1,1,1,1,1,1};
        pdf.PDFTableOlustur(doc, tablo, genislika, ToplamGenislik: 520);
        pdf.hucreEkle(tablo, "İl Adı", fonttip: "B", metinhiza:"C",kolonsayisi:2,kutu:"U1");
        pdf.hucreEkle(tablo, "İlçe Adı", fonttip: "B", metinhiza: "C", kolonsayisi: 2,kutu:"U");
        pdf.hucreEkle(tablo, "Oturum", fonttip: "B", metinhiza: "C", kutu: "U");
        pdf.hucreEkle(tablo, "Salon", fonttip: "B", metinhiza: "C", kutu: "U");

        pdf.hucreEkle(tablo, aciklamaBilgi.ilAdi, kolonsayisi: 2, kutu: "O1",satiryukseklik:24, metinhiza: "C");
        pdf.hucreEkle(tablo, aciklamaBilgi.ilceAdi, kolonsayisi: 2, kutu: "O", metinhiza: "C");
        pdf.hucreEkle(tablo, aciklamaBilgi.oturum, kutu: "O", metinhiza: "C");
        pdf.hucreEkle(tablo, aciklamaBilgi.salon, kutu: "O", metinhiza: "C");

        pdf.hucreEkle(tablo, " Bina Adı", kutu: "O1",fonttip:"B",metinhiza:"C");
        pdf.hucreEkle(tablo, aciklamaBilgi.binaAdi, kolonsayisi: 5, kutu: "O",satiryukseklik:30);


        
        pdf.hucreEkle(tablo, aciklamaBilgi.icerik, kolonsayisi: 6, kutu: "O1", satiryukseklik: 390,metinhiza:"J");

        return tablo;
    }

    PdfPTable TabloImza(Document doc, ImzaBilgi imzaBilgi)
    {
        PdfPTable tablo = new PdfPTable(5);
        int[] genislika = new int[] { 2,1, 4, 4, 4 };
        pdf.PDFTableOlustur(doc, tablo, genislika, ToplamGenislik: 520);
        pdf.hucreEkle(tablo, "Masa No ");
        pdf.hucreEkle(tablo, ":");
        pdf.hucreEkle(tablo, imzaBilgi.masaNo);
        pdf.hucreEkle(tablo, "Ekip Üyesi", metinhiza: "C");
        pdf.hucreEkle(tablo, "Ekip Başı", metinhiza: "C");


        pdf.hucreEkle(tablo, "Tarih ");
        pdf.hucreEkle(tablo, ":");
        pdf.hucreEkle(tablo, imzaBilgi.tarih);
        pdf.hucreEkle(tablo, imzaBilgi.ekipUyesi, metinhiza: "C");
        pdf.hucreEkle(tablo, imzaBilgi.ekipBasi, metinhiza: "C");

        pdf.hucreEkle(tablo, "Saat");
        pdf.hucreEkle(tablo, ":");
        pdf.hucreEkle(tablo, imzaBilgi.saat);
        pdf.hucreEkle(tablo, imzaBilgi.ekipUyeUnvani, metinhiza: "C");
        pdf.hucreEkle(tablo, imzaBilgi.ekipBasiUnvani, metinhiza: "C");


        pdf.hucreEkle(tablo, "",kolonsayisi:3);
        pdf.hucreEkle(tablo, "İmza",metinhiza:"C");
        pdf.hucreEkle(tablo, "İmza", metinhiza: "C");
        return tablo;
    }
}

class BelgeBilgi
{
    public string sinavAdi { get; set; }
    public string sinavTarihi { get; set; }
    public string dokumanKodu { get; set; }
    public string yayinTarihi { get; set; }
    public string revTarihi { get; set; }
    public string revizeNo { get; set; }
    public string sayfaNo { get; set; }

}

class AciklamaBilgi
{
 
    public string ilAdi { get; set; }
    public string ilceAdi { get; set; }
    public string oturum { get; set; }
    public string salon { get; set; }
    public string binaAdi { get; set; }
    public string icerik { get; set; }
}
class ImzaBilgi
{
     public string masaNo { get; set; }
    public string tarih { get; set; }
    public string saat { get; set; }
    public string ekipUyesi { get; set; }
    public string ekipUyeUnvani { get; set; }
    public string ekipBasi { get; set; }
    public string ekipBasiUnvani { get; set; }
}