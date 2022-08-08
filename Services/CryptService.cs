using System.Security.Cryptography;
using System.Text;

namespace Select_HtmlToPdf_NetCore.Services
{
    public class CryptService : ICryptService
    {
        public string Encrypt(string textToEncrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public string Decrypt(string textToDecrypt)
        {
             try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }

        // Java Script commands ==========================================
        // var txtUserName = $('#Username').val();  
        // var txtpassword = $('#Password').val(); 

        // var key = CryptoJS.enc.Utf8.parse('8080808080808080');  
        // var iv = CryptoJS.enc.Utf8.parse('8080808080808080');  
        // var encryptedlogin = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtUserName), key,  
        // {
        //     keySize: 128 / 8,   
        //     iv: iv,  
        //     mode: CryptoJS.mode.CBC,  
        //     padding: CryptoJS.pad.Pkcs7 
        // }); 

        // var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtpassword), key,  
        // { 
        // keySize: 128 / 8,   
        // iv: iv,  
        // mode: CryptoJS.mode.CBC,  
        // padding: CryptoJS.pad.Pkcs7
        // });  
        // Java Script commands ==========================================

        public  string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)  
        {  
            // Check arguments.  
            if (cipherText == null || cipherText.Length <= 0)  
            {  
                throw new ArgumentNullException("cipherText");  
            }  
            if (key == null || key.Length <= 0)  
            {  
                throw new ArgumentNullException("key");  
            }  
            if (iv == null || iv.Length <= 0)  
            {  
                throw new ArgumentNullException("key");  
            }  
        
            // Declare the string used to hold  
            // the decrypted text.  
            string plaintext = null;  
        
            // Create an RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())  
            {  
                //Settings  
                rijAlg.Mode = CipherMode.CBC;  
                rijAlg.Padding = PaddingMode.PKCS7;  
                rijAlg.FeedbackSize = 128;  
        
                rijAlg.Key = key;  
                rijAlg.IV = iv;  
        
                // Create a decrytor to perform the stream transform.  
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);  
        
                try  
                {  
                    // Create the streams used for decryption.  
                    using (var msDecrypt = new MemoryStream(cipherText))  
                    {  
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))  
                        {  
                            using (var srDecrypt = new StreamReader(csDecrypt))  
                            {  
                                // Read the decrypted bytes from the decrypting stream  
                                // and place them in a string.  
                                plaintext = srDecrypt.ReadToEnd();  
        
                            }  
        
                        }  
                    }  
                }  
                catch  
                {  
                    plaintext = "keyError";  
                }  
            }  
            
            return plaintext;  
        }

        public byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)  
        {  
            // Check arguments.  
            if (plainText == null || plainText.Length <= 0)  
            {  
                throw new ArgumentNullException("plainText");  
            }  
            if (key == null || key.Length <= 0)  
            {  
                throw new ArgumentNullException("key");  
            }  
            if (iv == null || iv.Length <= 0)  
            {  
                throw new ArgumentNullException("key");  
            }  
            byte[] encrypted;  
            // Create a RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())  
            {  
                rijAlg.Mode = CipherMode.CBC;  
                rijAlg.Padding = PaddingMode.PKCS7;  
                rijAlg.FeedbackSize = 128;  
        
                rijAlg.Key = key;  
                rijAlg.IV = iv;  
        
                // Create a decrytor to perform the stream transform.  
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);  
        
                // Create the streams used for encryption.  
                using (var msEncrypt = new MemoryStream())  
                {  
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))  
                    {  
                        using (var swEncrypt = new StreamWriter(csEncrypt))  
                        {  
                            //Write all data to the stream.  
                            swEncrypt.Write(plainText);  
                        }  
                        encrypted = msEncrypt.ToArray();  
                    }  
                }  
            }  
        
            // Return the encrypted bytes from the memory stream.  
            return encrypted;  
        }

        public string DecryptStringAES(string cipherText)  
        {  
            var keybytes = Encoding.UTF8.GetBytes("8080808080808080");  
            var iv = Encoding.UTF8.GetBytes("8080808080808080");  
        
            var encrypted = Convert.FromBase64String(cipherText);  
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);  
            return string.Format(decriptedFromJavascript);  
        }     
    }
}