using System;
using System.Collections.Generic;

class Orang
{
    public string nama { get; set; }
    public int umur { get; set; }

    public Orang(string nama, int umur)
    {
        this.nama = nama;
        this.umur = umur;
    }

    public virtual void Aktivitas()
    {
        Console.WriteLine($"{nama} sedang beraktivitas.");
    }

    public virtual void InfoOrang()
    {
        Console.WriteLine($"Nama: {nama}, Umur: {umur}");
    }
}

class Pasien : Orang
{
    public string keluhan { get; set; }

    public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
    {
        this.keluhan = keluhan;
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"Pasien {nama} sedang menunggu antrean.");
    }

    public void CekKeluhan()
    {
        Console.WriteLine($"Keluhan {nama}: {keluhan}");
    }

    public override void InfoOrang()
    {
        base.InfoOrang();
        Console.WriteLine($"Keluhan: {keluhan}");
    }
}

class TenagaMedis : Orang
{
    public string spesialisasi { get; set; }

    public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
    {
        this.spesialisasi = spesialisasi;
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"Tenaga medis {nama} sedang bertugas.");
    }

    public void CekSpesialis()
    {
        Console.WriteLine($"Spesialisasi {nama}: {spesialisasi}");
    }

    public override void InfoOrang()
    {
        base.InfoOrang();
        Console.WriteLine($"Spesialisasi: {spesialisasi}");
    }
}

class Dokter : TenagaMedis
{
    public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi) { }

    public override void Aktivitas()
    {
        Console.WriteLine($"Dokter {nama} sedang memeriksa pasien.");
    }

    public void Diagnosa()
    {
        Console.WriteLine($"Dokter {nama} sedang melakukan diagnosa.");
    }
}

class Perawat : TenagaMedis
{
    public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi) { }

    public override void Aktivitas()
    {
        Console.WriteLine($"Perawat {nama} sedang merawat pasien.");
    }

    public void CekPasien()
    {
        Console.WriteLine($"Perawat {nama} sedang mengecek kondisi pasien.");
    }
}

class PasienAnak : Pasien
{
    public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan) { }

    public override void Aktivitas()
    {
        Console.WriteLine($"Pasien anak {nama} sedang bermain.");
    }

    public void Menangis()
    {
        Console.WriteLine($"Pasien anak {nama} sedang menangis.");
    }
}

class PasienDewasa : Pasien
{
    public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan) { }

    public override void Aktivitas()
    {
        Console.WriteLine($"Pasien dewasa {nama} sedang beristirahat.");
    }

    public void Konsultasi()
    {
        Console.WriteLine($"Pasien dewasa {nama} sedang berkonsultasi.");
    }
}

class RumahSakit
{
    private List<Orang> daftarOrang = new List<Orang>();

    public void TambahOrang(Orang orang)
    {
        daftarOrang.Add(orang);
    }

    public void DaftarOrang()
    {
        foreach (var orang in daftarOrang)
        {
            orang.InfoOrang();
            orang.Aktivitas();
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RumahSakit rumahSakit = new RumahSakit();

        Dokter dokter = new Dokter("Tunggul", 40, "Spesialis Anak");
        Perawat perawat = new Perawat("Kholiush", 28, "Perawat Rawat Inap");
        PasienAnak pasienAnak = new PasienAnak("Geyrald", 6, "Demam");
        PasienDewasa pasienDewasa = new PasienDewasa("Excelymok", 45, "Pusing");

        rumahSakit.TambahOrang(dokter);
        rumahSakit.TambahOrang(perawat);
        rumahSakit.TambahOrang(pasienAnak);
        rumahSakit.TambahOrang(pasienDewasa);

        rumahSakit.DaftarOrang();

        dokter.Diagnosa();
        perawat.CekPasien();
        pasienAnak.Menangis();
        pasienDewasa.Konsultasi();

        Orang perawatPolimorfisme = new Perawat("Andromok", 30, "ICU");
        perawatPolimorfisme.Aktivitas();
    }
}