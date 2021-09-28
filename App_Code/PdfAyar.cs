using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PdfAyar
/// </summary>
public class PdfAyar
{
    public void hucreEkle(PdfPTable pdftabloadi, string metin = " ", string fonttip = "N",
        int fontboyut = 11, int satiryukseklik = 20, int kolonsayisi = 1, int satirsayisi = 1,
        float lsolcizgi = 0, float rsagcizgi = 0, float baltcizgi = 0, float tustcizgi = 0, string metinhiza = "L", string metinhizadikey = "C", int renk = 0, string kutu = "-", string yon = "")
    {
        BaseFont fontyol = BaseFont.CreateFont("C:\\windows\\fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font fontadi = new Font(fontyol, fontboyut, fonttip == "N" ? Font.NORMAL : fonttip == "B" ? Font.BOLD : fonttip == "I" ? Font.ITALIC : fonttip == "BI" ? Font.BOLDITALIC : fonttip == "U" ? Font.UNDERLINE : fonttip == "BU" ? Font.BOLD | Font.UNDERLINE: Font.STRIKETHRU);


        PdfPCell yenisatir = new PdfPCell(new Phrase(metin, fontadi));
        yenisatir.FixedHeight = satiryukseklik;
        yenisatir.Border = 0;
        yenisatir.Colspan = kolonsayisi;
        yenisatir.Rowspan = satirsayisi;
        if (renk == 1) yenisatir.BackgroundColor = new CMYKColor(71, 27, 7, 4);// BaseColor.YELLOW;
        if (renk == 2) yenisatir.BackgroundColor = new CMYKColor(55, 0, 5, 0);// BaseColor.YELLOW;
        if (renk == 3) yenisatir.BackgroundColor = new CMYKColor(0, 85, 90, 0);// BaseColor.YELLOW;
        if (renk == 4) yenisatir.BackgroundColor = new CMYKColor(0, 100, 65, 34);// BaseColor.YELLOW;
        if (renk == 5) yenisatir.BackgroundColor = new CMYKColor(0, 0, 0, 50);// BaseColor.YELLOW;
        

        yenisatir.BorderWidthLeft = lsolcizgi;
        yenisatir.BorderWidthTop = tustcizgi;
        yenisatir.BorderWidthBottom = baltcizgi;
        yenisatir.BorderWidthRight = rsagcizgi;


        if (kutu == "U1")
        {
            yenisatir.BorderWidthLeft = 1;
            yenisatir.BorderWidthTop = 1;
            yenisatir.BorderWidthBottom = 1;
            yenisatir.BorderWidthRight = 1;
        }
        if (kutu == "U")
        {

            yenisatir.BorderWidthTop = 1;
            yenisatir.BorderWidthBottom = 1;
            yenisatir.BorderWidthRight = 1;
        }
        if (kutu == "O1")
        {
            yenisatir.BorderWidthLeft = 1;
            yenisatir.BorderWidthBottom = 1;
            yenisatir.BorderWidthRight = 1;
        }
        if (kutu == "O")
        {

            yenisatir.BorderWidthBottom = 1;
            yenisatir.BorderWidthRight = 1;
        }


        if (metinhiza == "C") yenisatir.HorizontalAlignment = Element.ALIGN_CENTER;
        else if (metinhiza == "L") yenisatir.HorizontalAlignment = Element.ALIGN_LEFT;
        else if (metinhiza == "R") yenisatir.HorizontalAlignment = Element.ALIGN_RIGHT;
        else if (metinhiza == "J") yenisatir.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

        if (metinhizadikey == "C") yenisatir.VerticalAlignment = Element.ALIGN_CENTER;
        else if (metinhizadikey == "M") yenisatir.VerticalAlignment = Element.ALIGN_MIDDLE;
        else if (metinhizadikey == "T") yenisatir.VerticalAlignment = Element.ALIGN_TOP;
        else if (metinhizadikey == "B") yenisatir.VerticalAlignment = Element.ALIGN_BOTTOM;

        yenisatir.Padding = 4;
        if (yon == "1")
            yenisatir.Rotation = 90;


        pdftabloadi.AddCell(yenisatir);
    }


    public void yeniparagraf(Document doc, string metin = " ", string fonttip = "N", string hiza = "C", int fontboyut = 12)
    {
        BaseFont fontyol = BaseFont.CreateFont("C:\\windows\\fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font fontadi = new Font(fontyol, fontboyut, fonttip == "N" ? Font.NORMAL : fonttip == "B" ? Font.BOLD : fonttip == "I" ? Font.ITALIC : fonttip == "BI" ? Font.BOLDITALIC : fonttip == "U" ? Font.UNDERLINE :fonttip=="BU"?Font.BOLD | Font.UNDERLINE: Font.STRIKETHRU);
        //,new CMYKColor(0,0,0,34) gri renk
        Paragraph p1 = new Paragraph(metin, fontadi);
        if (hiza == "C") p1.Alignment = Element.ALIGN_CENTER;
        else if (hiza == "L") p1.Alignment = Element.ALIGN_LEFT;
        else if (hiza == "R") p1.Alignment = Element.ALIGN_RIGHT;
        else if (hiza == "J") p1.Alignment = Element.ALIGN_JUSTIFIED;
        doc.Add(p1);

    }


    public void PDFTableOlustur(Document doc, PdfPTable Table, int[] tablegenislikayar, int ToplamGenislik = 500, int Kenar = 0)
    {
        //PdfPTable TKonu = new PdfPTable(3);
        // int[] genislik1 = new int[] { 3, 10, 10 };
        Table.SetWidths(tablegenislikayar);
        Table.TotalWidth = ToplamGenislik;
        Table.DefaultCell.Border = Kenar;
        Table.LockedWidth = true;
        Table.DefaultCell.Phrase = new Phrase() { };
        doc.Add(Table);
    }

    public void PDFDosyaBasi(Document doc, MemoryStream output, int lM = 35, int rM = 35, int tM = 15, int bM = 15)
    {

        doc.SetMargins(lM, rM, tM, bM);
        PdfWriter.GetInstance(doc, output);
        doc.Open();

    }
    public void PDFDosyaSonu(MemoryStream output, string gosterimsekli = "e", string dosyaadi = "DT")
    {

        HttpContext.Current.Response.Clear();
        if (gosterimsekli == "e")
            HttpContext.Current.Response.AddHeader("content-disposition", "inline;");//ekrana aç
        else
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + dosyaadi + ".pdf;");//kaydet pdf

        //  Response.AddHeader("content-disposition", "attachment;filename="+(Session["X"] as Sessionlar).okulno+".pdf;");//kaydet pdf
        HttpContext.Current.Response.ContentType = "application/pdf";
        HttpContext.Current.Response.BinaryWrite(output.ToArray());
        HttpContext.Current.Response.End();
    }


    public void PdfKlasoreKaydet(MemoryStream output, string dosyaadi = "belge")
    {
        FileStream fs = File.Create(System.Web.HttpContext.Current.Server.MapPath("~/Belgeler/EkDers/" + dosyaadi + ".pdf"), 2048, FileOptions.None);
        BinaryWriter bw = new BinaryWriter(fs);
        byte[] ba = output.ToArray();
        bw.Write(ba);
        bw.Close();
        fs.Close();

    }


    public void dresimekle(PdfPTable t, string url, float scale, int align, int widh, int height, int satir_sayisi, float lsolcizgi = 0, float rsagcizgi = 0, float baltcizgi = 0, float tustcizgi = 0)
    {

        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(new Uri(url));
        //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));

        //  if (image.Width > 350) image.Width = 335;
        image.ScalePercent(image.Width < 420 ? scale : scale / 2 + 3);
        //    image.ScalePercent(scale);

        image.ScaleAbsolute(widh, height);

        PdfPCell cell = new PdfPCell(image);
        //cell.BorderColor = Color.WHITE;
        //cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 8f;
        cell.PaddingLeft = 8f;
        cell.PaddingRight = 8f;

        cell.PaddingTop = 8f;
        cell.BorderWidth = 1;
        cell.Rowspan = satir_sayisi;



        cell.BorderWidthLeft = lsolcizgi;
        cell.BorderWidthTop = tustcizgi;
        cell.BorderWidthBottom = baltcizgi;
        cell.BorderWidthRight = rsagcizgi;



        t.AddCell(cell);

    }
}