namespace Select_HtmlToPdf_NetCore.Services
{
    public interface ICryptService
    {
         string Encrypt(string textToEncrypt);
         string Decrypt(string textToDecrypt);

         string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv);
         byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv);
         string DecryptStringAES(string cipherText);
    }
}