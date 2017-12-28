﻿using System;
using System.Collections.Generic;
using Foundation;
using AppKit;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using NBitcoin;
using NBitcoin.DataEncoders;
using NBitcoin.BitcoinCore;
using NBitcoin.JsonConverters;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
//using Plugin.Clipboard;
//using System.Drawing.Imaging;
//using Zen;
//using Zen.Barcode;
//using QRCoder;

namespace EotCoinDesktopWallet
{
    public partial class MainWindowController : NSWindowController
    {
       
        public MainWindowController(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
        }

        public MainWindowController() : base("MainWindow")
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            SendAmount.EditingEnded += (sender, e) => {
                AmountEOTtextbox_TextChanged();
              /*  string amounttext = SendAmount.StringValue;
                decimal amounteot = Convert.ToDecimal(amounttext);
                decimal exchange = Utilities.ExchangeRates();
                decimal usd = amounteot / exchange;
                AmountDollar.StringValue = usd.ToString();*/
           };

            SendMinerFees.Changed += (sender, e) => {
                MinerFeesTextBox_TextChanged();
            };


            EOTLogoReceive.Image = NSImage.ImageNamed("EOT-3.png");
            EOTLogoSend.Image = NSImage.ImageNamed("EOT-3.png");
            ExportEOTLogo.Image = NSImage.ImageNamed("EOT-3.png");
            HistoryEOTLogo.Image = NSImage.ImageNamed("EOT-3.png");
            string address = "";
            string path = "/Users/Shared/Library/Application Support/com.eotwallet.Eot-Coin-Wallet/Address.txt";
            if (File.Exists(path))
            {
                address = File.ReadLines(path).First();
            }
           // WalletAddressLabel.StringValue = address;
           // BalanceNumberLabel.StringValue = Utilities.GetAddressBalance(WalletAddressLabel.StringValue).ToString() + " EOT";
           // WalletBalanceSend.StringValue = BalanceNumberLabel.StringValue;
           // HistoryBalance.StringValue = BalanceNumberLabel.StringValue;
            Refresh();

        }

        partial void GenerateWalletButtonClick(Foundation.NSObject sender)
        {
           // if (RandomCharsBox.StringValue.Length < 120)
           // {
             //   System.Windows.Forms.MessageBox.Show("Please enter 120 random characters");
           // }
           // else
           // {
                string Password = PasswordBox.StringValue;
                string inputString = RandomCharsBox.StringValue;

                Random rnd = new Random();
                string seed = Utilities.generateSeed(inputString, rnd);

                List<string> keyPair = Utilities.getKeyPair(seed);
                string eotPrivateKey = keyPair.ElementAt(0);
                string eotAddress = keyPair.ElementAt(1);

                Wallet eotWallet = new Wallet(eotPrivateKey, eotAddress, seed);
                Utilities.FileEncrypt(seed, Password);
                Utilities.printWalletToFile(eotWallet);

                WalletLabel.StringValue = eotWallet.eotAddress;
                //ClickedLabel.StringValue = Utilities.FileDecrypt("wallet.eot", Password);
                //EOTCoinWalletDashboard dashboardform = new EOTCoinWalletDashboard();
                //dashboardform.Show();
                //  this.Hide();
                //}
          //  }


        }
        partial void RefreshButtonClick(Foundation.NSObject sender)
        {
            string address = "";
            string path = "/Users/Shared/Library/Application Support/com.eotwallet.Eot-Coin-Wallet/Address.txt";
            if (File.Exists(path))
            {
                address = File.ReadLines(path).First();
            }

            WalletAddressLabel.StringValue = address;
            BalanceNumberLabel.StringValue = Utilities.GetAddressBalance(WalletAddressLabel.StringValue).ToString()+ " EOT";
            WalletBalanceSend.StringValue = BalanceNumberLabel.StringValue;
            HistoryBalance.StringValue = BalanceNumberLabel.StringValue;
            Refresh();
            //Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            // qrcode

            //qrcode.Draw(address, metrics);
            //NSImage QRCodeImage = qrcode.Draw(WalletAddressLabel.StringValue, 55);
            //QCodePictureBox.Image = qrcode.Draw(WalletAddressLabel.StringValue, 55);
           // ZXing.IBarcodeWriterGeneric writer = new
          //  ZXing.QrCode.QRCodeWriter writer = new ZXing.QrCode.QRCodeWriter();
       //     QRCodeGenerator qrGenerator = new QRCodeGenerator();
         //   QRCodeData qrCodeData = qrGenerator.CreateQrCode(address, QRCodeGenerator.ECCLevel.Q);
        //    AsciiQRCode qrCode = new AsciiQRCode(qrCodeData);
         //   string qrCodeAsAsciiArt = qrCode.GetGraphic(1);
         //   // ZXing.Mobile
            //  NSImage image = writer.encode(address, ZXing.BarcodeFormat.QR_CODE, 200, 200);
            // SkiaSharp.SKBitmap bitmap;
            //  FileStream imagefile = new FileStream("qrcode.bmp", FileMode.Create);
            //    imagefile.Write(bm., 0, bm.Height);
            // QRCodePictureBox = qrCodeImage;  
         //   QRCodeLabel.StringValue = qrCodeAsAsciiArt;


        }

    /*    public SKBitmap Render(BitMatrix matrix, BarcodeFormat format, string content)
        {
            return Render(matrix, format, content, new EncodingOptions());
        }*/

        partial void RefreshTransactionButtonClick(Foundation.NSObject sender)
        {
            string[] arr = new string[7];
            // ListViewItem itm;
            //EOTAddressLabel.Text = Utilities.readTxtFile();
            WalletAddressLabel.StringValue = Utilities.readTxtFile();
            BalanceNumberLabel.StringValue = Utilities.GetAddressBalance(WalletAddressLabel.StringValue).ToString() + " EOT";
            HistoryBalance.StringValue = BalanceNumberLabel.StringValue;
            WalletBalanceSend.StringValue = BalanceNumberLabel.StringValue;
           // BalanceLabel2.Text = Utilities.GetAddressBalance(EOTAddressLabel.Text).ToString() + " EOT";
            var DataSource = new TransactionHistoryDataSource();


                List<TransactionHistoryEOT> list = Utilities.GetEOTTransactionInfo(WalletAddressLabel.StringValue);

                for (int i = 0; i < list.Count(); i++)
                {
                    arr[0] = list.ElementAt(i).Date.ToString();

                    // DateColumn.Value = arr[0];
                    arr[1] = list.ElementAt(i).Amount.ToString();
                    arr[2] = list.ElementAt(i).TxStatus;

                    if (list.ElementAt(i).Type == "0")
                    {
                        arr[3] = "Sent";
                    }
                    else if (list.ElementAt(i).Type == "1")
                    {
                        arr[3] = "Received";
                    }

                    //arr[3] = list.ElementAt(i).Type;
                    arr[4] = list.ElementAt(i).Address[0];
                    arr[5] = list.ElementAt(i).TransactionId;
                    DataSource.Transactions.Add(new TransactionHistory(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5]));
                    //itm = new ListViewItem(arr);
                    //TransactionsView.Items.Add(itm);
                }



            TransactionTable.DataSource = DataSource;
            // ProductTable.DataSource = DataSource;
            TransactionTable.Delegate = new TransactionHistoryDelegate(DataSource);
        //    ProductTable.Delegate = new ProductTableDelegate(DataSource);
        }

        public void Refresh()
        {
            string[] arr = new string[7];
            // ListViewItem itm;
            //EOTAddressLabel.Text = Utilities.readTxtFile();
            WalletAddressLabel.StringValue = Utilities.readTxtFile();
            BalanceNumberLabel.StringValue = Utilities.GetAddressBalance(WalletAddressLabel.StringValue).ToString() + " EOT";
            HistoryBalance.StringValue = BalanceNumberLabel.StringValue;
            WalletBalanceSend.StringValue = BalanceNumberLabel.StringValue;
            // BalanceLabel2.Text = Utilities.GetAddressBalance(EOTAddressLabel.Text).ToString() + " EOT";
            var DataSource = new TransactionHistoryDataSource();


            List<TransactionHistoryEOT> list = Utilities.GetEOTTransactionInfo(WalletAddressLabel.StringValue);

            for (int i = 0; i < list.Count(); i++)
            {
                arr[0] = list.ElementAt(i).Date.ToString();

                // DateColumn.Value = arr[0];
                arr[1] = list.ElementAt(i).Amount.ToString();
                arr[2] = list.ElementAt(i).TxStatus;

                if (list.ElementAt(i).Type == "0")
                {
                    arr[3] = "Sent";
                }
                else if (list.ElementAt(i).Type == "1")
                {
                    arr[3] = "Received";
                }

                //arr[3] = list.ElementAt(i).Type;
                arr[4] = list.ElementAt(i).Address[0];
                arr[5] = list.ElementAt(i).TransactionId;
                DataSource.Transactions.Add(new TransactionHistory(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5]));
                //itm = new ListViewItem(arr);
                //TransactionsView.Items.Add(itm);
            }



            TransactionTable.DataSource = DataSource;
            // ProductTable.DataSource = DataSource;
            TransactionTable.Delegate = new TransactionHistoryDelegate(DataSource);
            //    ProductTable.Delegate = new ProductTableDelegate(DataSource);
        }


        partial void SendEOTButtonClick(Foundation.NSObject sender)
        {
            if (SendToAddress.StringValue != " " && SendToAddress != null)
            {
                if (SendAmount.StringValue != "" && SendAmount.StringValue != " " && SendAmount.StringValue != null) //check if amount and miner fees are numeric
                {
                    if (SendMinerFees.StringValue != " " && SendMinerFees.StringValue != null)
                    {
                        if (SendPassword.StringValue != " " && SendPassword.StringValue != null)
                        {
                            Send();
                        }
                    }
                    else
                    {
                        var alert = new NSAlert()
                        {
                            AlertStyle = NSAlertStyle.Informational,
                            InformativeText = "You must enter an amount of miner fees to send!",
                            MessageText = "EOT Coin Wallet",
                        };
                        alert.RunModal();
                    }
                       // System.Windows.Forms.MessageBox.Show("You must enter an amount of miner fees to send!");
                }
                else
                {
                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = "You must enter an amount of EOT coins to send!",
                        MessageText = "EOT Coin Wallet",
                    };
                    alert.RunModal();
                }
                  //  System.Windows.Forms.MessageBox.Show("You must enter an amount of EOT coins to send!");
            }
            else
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = "Receiving address must not be empty!",
                    MessageText = "EOT Coin Wallet",
                };
                alert.RunModal();
                //System.Windows.Forms.MessageBox.Show("Receiving address must not be empty!");
            }
        }

        public void Send()
        {
            string password = SendPassword.StringValue;
            string seed = Utilities.FileDecrypt("/Users/Shared/Library/Application Support/com.eotwallet.Eot-Coin-Wallet/wallet.eot", password);
            string address = "";
            string path = "/Users/Shared/Library/Application Support/com.eotwallet.Eot-Coin-Wallet/Address.txt";
            if (File.Exists(path))
            {
                address = File.ReadLines(path).First();
            }

            List<string> keyPair = Utilities.getKeyPair(seed);
            string eotPrivateKey = keyPair.ElementAt(0);
            string eotAddress = keyPair.ElementAt(1);
            Wallet eotWallet = new Wallet(eotPrivateKey, eotAddress, seed);

            if (eotWallet.eotAddress == address) //password matches
            {
                string receivingAddress = SendToAddress.StringValue;
                decimal amount = Convert.ToDecimal(SendAmount.StringValue);
                double minerFees = Convert.ToDouble(SendMinerFees.StringValue);
                string vendorAddress = "EerE2Vp8M4RAypufWsDZ3UHvQphHy99R1Q"; //merchant address 
                decimal transactionFees = 0.000m; //no transaction fee applied

                //check balance first
                if (Utilities.GetAddressBalance(eotWallet.eotAddress) >= (amount + Convert.ToDecimal(minerFees)))
                {
                    bool success = PerformEOTTransaction(eotWallet.eotPrivateKey, eotWallet.eotAddress, vendorAddress, transactionFees, receivingAddress, amount, minerFees);
                    if (success)
                    {
                       // System.Windows.Forms.MessageBox.Show("Transaction successfully processed!");
                        var alert = new NSAlert()
                        {
                            AlertStyle = NSAlertStyle.Informational,
                            InformativeText = "Transaction successfully processed!",
                            MessageText = "EOT Coin Wallet",
                        };
                        alert.RunModal();
                        SendPassword.StringValue = "";
                        SendAmount.StringValue = "";
                        SendMinerFees.StringValue = "";
                        SendToAddress.StringValue = "";
                    }
                    else
                    {
                       // System.Windows.Forms.MessageBox.Show("Transaction failed: Not enough funds to process transaction!");
                        var alert = new NSAlert()
                        {
                            AlertStyle = NSAlertStyle.Informational,
                            InformativeText = "Transaction failed: Not enough funds to process transaction!",
                            MessageText = "EOT Coin Wallet",
                        };
                        alert.RunModal();
                    
                    }
                }
                else
                {
                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = "Not enough funds to process transaction!",
                        MessageText = "EOT Coin Wallet",
                    };
                    alert.RunModal();
                }
                   // System.Windows.Forms.MessageBox.Show("Not enough funds to process transaction!");
            }
            else
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = "Incorrect password!",
                    MessageText = "EOT Coin Wallet",
                };
                alert.RunModal();
               // System.Windows.Forms.MessageBox.Show("Incorrect password!");
            }
        }

        public static bool PerformEOTTransaction(string bitcoinSecret, string senderAddress, string eotVendorAddress, decimal transactionFees, string receiverAddress, decimal amount, double minerfees)
        {
            bool result = false;
            try
            {
                //Transacion Builder handles the confirmations
                var me = BitcoinAddress.Create(senderAddress);
                TransactionBuilder builder = new TransactionBuilder();
                List<Coin> coins;
               // BitcoinAddress.Create(string str);
                coins = GetCoinList(senderAddress);
                Transaction transaction =
                    builder
                    .AddCoins(coins)
                    .AddKeys(new BitcoinSecret(bitcoinSecret))
                        .Send(BitcoinAddress.Create(receiverAddress, Network.EOTNet), Money.Coins(amount))
                        .Send(BitcoinAddress.Create(eotVendorAddress, Network.EOTNet), Money.Coins(transactionFees))
                    .SendFees(Money.Coins(Convert.ToDecimal(minerfees)))
                    .SetChange(me).BuildTransaction(true);

                result = PushTransaction(transaction.ToHex());

                return result;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Transaction Failed -- Colm testing: " + ex.Message);
                //Console.ReadKey();
            }
            return result;
        }

        public static List<Coin> GetCoinList(string address)
        {
            try
            {
                string ApiBaseAddressForEOT = "http://178.62.30.50:3622/api";
                string URL = ApiBaseAddressForEOT + "/addr/" + address + "/utxo";
                List<Coin> coins = new List<Coin>();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client.GetAsync(URL).Result;  // Blocking call!
                if (response1.IsSuccessStatusCode)
                {
                    var dataObjects = response1.Content.ReadAsStringAsync().Result;
                    var json = JArray.Parse(dataObjects);
                    foreach (var li in json)
                    {
                        {
                           // string txids = li["txid"].ToString();
                           // uint256 txidu = uint256(txids);
                            UInt32 voutu = Convert.ToUInt32(li["vout"].ToString());
                            decimal satoshis = Convert.ToDecimal(li["amount"].ToString()) * 100000000;
                          //  string scripts = Script(Encoders.Hex.DecodeData(li["scriptPubKey"].ToString();

                            //var coin = new Coin(new txidu, voutu, satoshis, new scripts)));

                            var coin = new Coin(new
                                                uint256(li["txid"].ToString()), Convert.ToUInt32(li["vout"].ToString()), Money.Satoshis(satoshis), new
                            Script(Encoders.Hex.DecodeData(li["scriptPubKey"].ToString())));
                            
                            coins.Add(coin);

                        }
                    }
                    return coins;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Exception in GetCoinListUsingPrimaryAPI method, Message : " + ex.Message);
            }
            return null;
        }

        public static bool PushTransaction(string hex)
        {
            try
            {
                HttpClient client = new HttpClient();
                string ApiBaseAddressForEOT = "http://178.62.30.50:3622/api";
                string URL = ApiBaseAddressForEOT + "/tx/send";
                var tx = "{\"rawtx\":" + "\"" + hex + "\"}";
                string _ContentType = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                HttpContent _Body = new StringContent(tx);
                // and add the header to this object instance
                // optional: add a formatter option to it as well
                _Body.Headers.ContentType = new MediaTypeHeaderValue(_ContentType);
                // synchronous request without the need for .ContinueWith() or await
                var response = client.PostAsync(new Uri(URL), _Body).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Exception in PushTransaction method. :" + ex.ToString());
                return false;
            }
        }


        private void AmountEOTtextbox_TextChanged()
        {
            try
            {
                string amounttext = SendAmount.StringValue;
                decimal amounteot = Convert.ToDecimal(amounttext);
                decimal exchange = Utilities.ExchangeRates();
                decimal usd = amounteot / exchange;
                AmountDollar.StringValue = usd.ToString() + " $";
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("Amount must the numberic");
            }
        }

        private void MinerFeesTextBox_TextChanged()
        {
            try
            {
                string amountminerfees = SendMinerFees.StringValue;
                decimal amounteot = Convert.ToDecimal(amountminerfees);
                decimal exchange = Utilities.ExchangeRates();
                decimal usd = amounteot / exchange;
                MinerFeesDollar.StringValue = usd.ToString() + " $";
            }
            catch (Exception ex)
            {
                //   System.Windows.Forms.MessageBox.Show("Amount must the numberic");
            }

        }

        partial void ExportSeedButtonClick(Foundation.NSObject sender)
        {
            string password = ExportPassword.StringValue;

            string eotSeed = Utilities.FileDecrypt("/Users/Shared/Library/Application Support/com.eotwallet.Eot-Coin-Wallet/wallet.eot", password);

            string txtAddress = Utilities.readTxtFile();

            List<string> keyPair = Utilities.getKeyPair(eotSeed);
            string eotPrivateKey = keyPair.ElementAt(0);
            string eotAddress = keyPair.ElementAt(1);
            Wallet eotWallet = new Wallet(eotPrivateKey, eotAddress, eotSeed);

            if (eotWallet.eotAddress == txtAddress)
            {
                
              //  seedLabel.Text = "Please keep this wallet seed safe \nIf someone gets your wallet seed they can steal your coins";
              //  seedLabel.ForeColor = Color.FromArgb(255, 0, 0);
              //  seedLabel.Visible = true;

              //  seedTextBox.Text = eotWallet.eotSeed;
              //  seedTextBox.Visible = true;

              //  ExportButton.Visible = false;
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = eotWallet.eotSeed,
                    MessageText = "EOT Coin Wallet - Wallet Seed",
                };
                alert.RunModal();
            }
            else
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = "Incorrect password!",
                    MessageText = "EOT Coin Wallet",
                };
                alert.RunModal();

              //  System.Windows.Forms.MessageBox.Show("Incorrect password!");
            }
            ExportPassword.StringValue = "";
        }

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }
    }
}