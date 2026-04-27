using System;
namespace modul8_103082400003;
class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig configManager = new BankTransferConfig();
        var config = configManager.config;

        // Input Nominal
        if (config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        int nominal = int.Parse(Console.ReadLine());

        // Hitung Biaya
        int biayaTransfer = (nominal <= config.transfer.threshold) ? config.transfer.low_fee : config.transfer.high_fee;
        int totalBiaya = nominal + biayaTransfer;

        if (config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biayaTransfer}");
            Console.WriteLine($"Total amount = {totalBiaya}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {biayaTransfer}");
            Console.WriteLine($"Total biaya = {totalBiaya}");
        }

        // Pilih Metode
        Console.WriteLine(config.lang == "en" ? "Select transfer method:" : "Pilih metode transfer:");
        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }
        string methodInput = Console.ReadLine();

        // Konfirmasi
        string targetConfirm = (config.lang == "en") ? config.confirmation.en : config.confirmation.id;

        if (config.lang == "en")
        {
            Console.Write($"Please type \"{targetConfirm}\" to confirm the transaction: ");
        }
        else
        {
            Console.Write($"Ketik \"{targetConfirm}\" untuk mengkonfirmasi transaksi: ");
        }

        string confirmInput = Console.ReadLine();

        // Hasil Akhir
        if (confirmInput == targetConfirm)
        {
            Console.WriteLine(config.lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        }
        else
        {
            Console.WriteLine(config.lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        }
    }
}