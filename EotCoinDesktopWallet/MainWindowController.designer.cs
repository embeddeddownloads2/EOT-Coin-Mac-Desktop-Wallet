﻿// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace EotCoinDesktopWallet
{
    [Register ("MainWindowController")]
    partial class MainWindowController
    {
        [Outlet]
        AppKit.NSTableColumn AmountColumn { get; set; }

        [Outlet]
        AppKit.NSTextField AmountDollar { get; set; }

        [Outlet]
        AppKit.NSTextField BalanceNumberLabel { get; set; }

        [Outlet]
        AppKit.NSTableColumn DateColumn { get; set; }

        [Outlet]
        AppKit.NSImageView EOTLogoReceive { get; set; }

        [Outlet]
        AppKit.NSImageView EOTLogoSend { get; set; }

        [Outlet]
        AppKit.NSImageView ExportEOTLogo { get; set; }

        [Outlet]
        AppKit.NSSecureTextField ExportPassword { get; set; }

        [Outlet]
        AppKit.NSTextField HistoryBalance { get; set; }

        [Outlet]
        AppKit.NSImageView HistoryEOTLogo { get; set; }

        [Outlet]
        AppKit.NSTextField MinerFeesDollar { get; set; }

        [Outlet]
        AppKit.NSSecureTextField PasswordBox { get; set; }

        [Outlet]
        AppKit.NSTextFieldCell QRCodeLabel { get; set; }

        [Outlet]
        AppKit.NSTextField RandomCharsBox { get; set; }

        [Outlet]
        AppKit.NSTextField SendAmount { get; set; }

        [Outlet]
        AppKit.NSTextField SendMinerFees { get; set; }

        [Outlet]
        AppKit.NSSecureTextField SendPassword { get; set; }

        [Outlet]
        AppKit.NSTextField SendToAddress { get; set; }

        [Outlet]
        AppKit.NSTableColumn StatusColumn { get; set; }

        [Outlet]
        AppKit.NSTableView TransactionTable { get; set; }

        [Outlet]
        AppKit.NSTableHeaderView TransactionTableHeader { get; set; }

        [Outlet]
        AppKit.NSTextField WalletAddressLabel { get; set; }

        [Outlet]
        AppKit.NSTextField WalletBalanceSend { get; set; }

        [Outlet]
        AppKit.NSTextField WalletLabel { get; set; }

        [Action ("CopyButtonClick:")]
        partial void CopyButtonClick (Foundation.NSObject sender);

        [Action ("ExportSeedButtonClick:")]
        partial void ExportSeedButtonClick (Foundation.NSObject sender);

        [Action ("GenerateWalletButtonClick:")]
        partial void GenerateWalletButtonClick (Foundation.NSObject sender);

        [Action ("RefreshButtonClick:")]
        partial void RefreshButtonClick (Foundation.NSObject sender);

        [Action ("RefreshTransactionButtonClick:")]
        partial void RefreshTransactionButtonClick (Foundation.NSObject sender);

        [Action ("SendEOTButtonClick:")]
        partial void SendEOTButtonClick (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (WalletBalanceSend != null) {
                WalletBalanceSend.Dispose ();
                WalletBalanceSend = null;
            }

            if (AmountColumn != null) {
                AmountColumn.Dispose ();
                AmountColumn = null;
            }

            if (AmountDollar != null) {
                AmountDollar.Dispose ();
                AmountDollar = null;
            }

            if (BalanceNumberLabel != null) {
                BalanceNumberLabel.Dispose ();
                BalanceNumberLabel = null;
            }

            if (DateColumn != null) {
                DateColumn.Dispose ();
                DateColumn = null;
            }

            if (EOTLogoReceive != null) {
                EOTLogoReceive.Dispose ();
                EOTLogoReceive = null;
            }

            if (EOTLogoSend != null) {
                EOTLogoSend.Dispose ();
                EOTLogoSend = null;
            }

            if (MinerFeesDollar != null) {
                MinerFeesDollar.Dispose ();
                MinerFeesDollar = null;
            }

            if (PasswordBox != null) {
                PasswordBox.Dispose ();
                PasswordBox = null;
            }

            if (QRCodeLabel != null) {
                QRCodeLabel.Dispose ();
                QRCodeLabel = null;
            }

            if (RandomCharsBox != null) {
                RandomCharsBox.Dispose ();
                RandomCharsBox = null;
            }

            if (SendAmount != null) {
                SendAmount.Dispose ();
                SendAmount = null;
            }

            if (SendMinerFees != null) {
                SendMinerFees.Dispose ();
                SendMinerFees = null;
            }

            if (SendPassword != null) {
                SendPassword.Dispose ();
                SendPassword = null;
            }

            if (SendToAddress != null) {
                SendToAddress.Dispose ();
                SendToAddress = null;
            }

            if (StatusColumn != null) {
                StatusColumn.Dispose ();
                StatusColumn = null;
            }

            if (TransactionTable != null) {
                TransactionTable.Dispose ();
                TransactionTable = null;
            }

            if (TransactionTableHeader != null) {
                TransactionTableHeader.Dispose ();
                TransactionTableHeader = null;
            }

            if (WalletAddressLabel != null) {
                WalletAddressLabel.Dispose ();
                WalletAddressLabel = null;
            }

            if (HistoryEOTLogo != null) {
                HistoryEOTLogo.Dispose ();
                HistoryEOTLogo = null;
            }

            if (HistoryBalance != null) {
                HistoryBalance.Dispose ();
                HistoryBalance = null;
            }

            if (WalletLabel != null) {
                WalletLabel.Dispose ();
                WalletLabel = null;
            }

            if (ExportEOTLogo != null) {
                ExportEOTLogo.Dispose ();
                ExportEOTLogo = null;
            }

            if (ExportPassword != null) {
                ExportPassword.Dispose ();
                ExportPassword = null;
            }
        }
    }
}
