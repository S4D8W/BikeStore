﻿using BikeStore.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure {
  public enum LanguageEnum {
    None = 0,
    Poland = 1,
    UK = 2,
  }

  public enum TextEnum {
    Name = 1,
    SurName = 2,
    Email = 3,
    Password = 4,
    ConfirmPassword = 5,
    SignUp = 6,
    ThisFieldIsRequired = 7,
    ThisEmailAddressAlreadyExist = 8,
    YoursPasswordMustByMinLenghtEightCharacters = 9,
    YoursPasswordDoesntMatchConfirmPasswordField = 10,
    LogIn = 11,
    ForGotYourPassword = 12,
    TheUsernameordidnotmatchPleaseTryAgain = 13,
    EnterYourEmailAddressBelowAndWellSendYouANewPassword = 14,
    Submit = 15,
    MyAccount = 16,
    AccountDetails = 17,
    Since = 18,
    LoginDetails = 19,
    ChangePassword = 20,
    ChangeEmail = 21,
    OldPassword = 22,
    NewPassword = 23,
    ConfirmNewPassword = 24,
    IncorrectPassword = 25,
    Account = 26,
    LastLogIn = 27,
    Notifications = 28,
    Shop = 29,
    AddProduct = 30,
    Name_Product = 31,
    Description = 32,
    Price = 33,
    Category = 34,
    Images = 35,
    AddCategory = 36,
    Confirm = 37,
    ProductsList = 38,
    SelectCategory = 39,
    Delete = 40,
    Edit = 41,
    BackToList = 42,
    Close = 43,
    Quantity = 44,
    CreationDate = 45,
    AddToShopCart = 46,
    Product = 47,
    Together = 48,
    PurchaseValue = 49,
    SearchForTheNextProduct = 50,
    GoToPayment = 51,
    ChooseYourDeliveryOrCollectionMethod = 52,
    Courier = 53,
    PersonalPickup = 54,
    InPost = 55,
    ChooseYourPaymentMethod = 56,
    CashOnDelivery = 57,
    BankTransver = 58,
    PayU = 59,
    EnterYourShippingData = 60,
    Address = 61,
    ZipCodeAndCity = 62,
    PhoneNumber = 63,
    IWantToSendThisPackageToADifferentAddress = 64,
    IWantToProvideOtherDetailsForTheInvoice = 65,
    IWantToAddNotesToTheOrder = 66,
    EnterYourCommentsOnTheOrderHere = 67,
    IAcceptTheTermsAndConditionsOfTheShop = 68,
    IAgreeToIssueAndSendAnInvoiceInElectronicForm =69,
    Citi = 70,
    ZipCode = 71,
    TheMethodOfPaymentChosen = 72,
    SelectedDeliveryMethod = 73,
    ShippingData = 74,
    NoDataToDisplay = 75,
  }

  public class Languages {



    private int IDX_LANG_WINCON_POLISH;          //indeks języka polskiego w bazie WinCon

    //teksty indywidualne strony WWW
    private static Dictionary<TextEnum, string> mCln_Pl;
    private static Dictionary<TextEnum, string> mCln_En;
    private static Dictionary<TextEnum, string> mCln_Rus;
    private static int mIdxAppLanguage;
    private static int mCurrentCntAppLanguage;
    public string AppTittle = "Oknovid Window";

    private static Dictionary<int, Dictionary<int, string>> mCln_WinCon;
    private static IHttpContextAccessor mHttpContextAccessor;

    public Languages(IHttpContextAccessor xHttpContextAccessor) {

      mHttpContextAccessor = xHttpContextAccessor;

      mCln_Pl = new Dictionary<TextEnum, string>();
      mCln_En = new Dictionary<TextEnum, string>();
      mCln_Rus = new Dictionary<TextEnum, string>();

      mCln_WinCon = new Dictionary<int, Dictionary<int, string>>();

      Initialize();

    }


    public static string GetText(TextEnum xCntText) {

      int pCntAppLanguage;

      pCntAppLanguage = mHttpContextAccessor.HttpContext.Session?.GetInt32(SessionEnum.CntAppLanguage.ToString()) ?? 1;

      switch ((int)pCntAppLanguage) {
        case (int)LanguageEnum.Poland:
        return mCln_Pl[xCntText];
        case (int)LanguageEnum.UK:
        return mCln_En[xCntText];
      }

      return mCln_En[xCntText];

    }

    private void Initialize() {
      //funkcja inicjalizująca  teksty

      InitializeTextes_WebSite();                           //teksty Oknovid

    }

    private void InitializeTextes_WebSite() {
      //inicjalizacja tekstów indywidualnych dla aplikacji 
      AddText(TextEnum.Name, "Name", "Imie");
      AddText(TextEnum.SurName, "Surname", "Nazwisko");
      AddText(TextEnum.Email, "Email", "Email");
      AddText(TextEnum.SignUp, "Sign up", "Zarejestruj się");
      AddText(TextEnum.ThisFieldIsRequired, "This field is rquired", "Te pole jest wymagane");
      AddText(TextEnum.ThisEmailAddressAlreadyExist, "This email address already exist", "Ten ades e-mail już istnieje");
      AddText(TextEnum.YoursPasswordMustByMinLenghtEightCharacters, "Yours password must by min lenght eight characters", "Twoje chasło musi mieć conajmiej osiem znaków");
      AddText(TextEnum.YoursPasswordDoesntMatchConfirmPasswordField, "Yours password doesn't match confirm password field", "Twoje chasła nie są takie same");
      AddText(TextEnum.Password, "Password", "Hasło");
      AddText(TextEnum.ConfirmPassword, "Confirm password", "Potwierdź hasło");
      AddText(TextEnum.LogIn, "Log In", "Logowanie");
      AddText(TextEnum.ForGotYourPassword, "Forgot your password?", "Zapomniałeś hasła");
      AddText(TextEnum.TheUsernameordidnotmatchPleaseTryAgain, "The username or password did not match, Please try again", "Twoje nazwa urzytkownika i hasło nie pasują, spróbuj ponownie");
      AddText(TextEnum.EnterYourEmailAddressBelowAndWellSendYouANewPassword, "Enter your email address below and we'll send you a new password", "Wpisz poniżej swój adres e-mail, a my wyślemy Ci nowe hasło");
      AddText(TextEnum.Submit, "Submit", "Prześlij");
      AddText(TextEnum.MyAccount, "MyAccount", "Moje konto");
      AddText(TextEnum.AccountDetails, "Account details", "Szczeguły konta");
      AddText(TextEnum.Since, "Since", "Od kiedy");
      AddText(TextEnum.LoginDetails, "Login details", "Dane logowania");
      AddText(TextEnum.ChangeEmail, "Change email", "Zmień email");
      AddText(TextEnum.ChangePassword, "Change password", "zmień hasło");
      AddText(TextEnum.OldPassword, "Old password", "Stare hasło");
      AddText(TextEnum.NewPassword, "New password", "Nowe hasło");
      AddText(TextEnum.ConfirmNewPassword, "Confirm new password", "Potwierdź nowe hasło");
      AddText(TextEnum.IncorrectPassword, "Incorrect password", "Niepoprawne hasło");
      AddText(TextEnum.Account, "Account", "Konto");
      AddText(TextEnum.LastLogIn, "Last Log-in", "Ostatnie logowanie");
      AddText(TextEnum.Notifications, "Notifications", "Zgłoszenia");
      AddText(TextEnum.Shop, "Shop", "Sklep");
      AddText(TextEnum.AddProduct, "Add product", "Dodaj produkt");
      AddText(TextEnum.Name_Product, "Name", "Nazwa");
      AddText(TextEnum.Description, "Description", "Opis");
      AddText(TextEnum.Price, "Price", "Cena");
      AddText(TextEnum.Images, "Images", "Zdjęcia");
      AddText(TextEnum.Category, "Category", "Kategoria");
      AddText(TextEnum.AddCategory, "Add category", "Dodaj kategorie");
      AddText(TextEnum.Confirm, "Confirm", "Zatwierdź");
      AddText(TextEnum.ProductsList, "Product list", "Lista produktów");
      AddText(TextEnum.SelectCategory, "Select category", "Wybirz kategorię");
      AddText(TextEnum.Edit, "Edit", "Edytuj");
      AddText(TextEnum.Delete, "Delete", "Usuń");
      AddText(TextEnum.BackToList, "Back to list", "Powrót do listy");
      AddText(TextEnum.Close, "Close", "Zamknij");
      AddText(TextEnum.Quantity, "Quantity", "Ilość");
      AddText(TextEnum.CreationDate, "Creation date", "Data utworzenia");
      AddText(TextEnum.AddToShopCart, "Add to shop cart", "Dodaj to koszyka");
      AddText(TextEnum.Product, "Product", "Produkt");
      AddText(TextEnum.Together, "Together", "Razem");
      AddText(TextEnum.PurchaseValue, "Purchase value", "Wartość zakpów");
      AddText(TextEnum.SearchForTheNextProduct, "Search for the next product", "Szukaj kolejnego produktu");
      AddText(TextEnum.GoToPayment, "Go to payment", "Przjdź do płatność");
      AddText(TextEnum.ChooseYourDeliveryOrCollectionMethod, "Choose your delivery or collection method", " Wybierz sposób dostawy lub odbioru");
      AddText(TextEnum.Courier, "Courier", "Kurier");
      AddText(TextEnum.PersonalPickup, "Personal pickuo", "Odbiur osobisty");
      AddText(TextEnum.InPost, "InPost", "InPost");
      AddText(TextEnum.ChooseYourPaymentMethod, "Choose your payment method", "Wybierz system płatność");
      AddText(TextEnum.CashOnDelivery, "Cash on delivery", "Gotówka przy odbiorze");
      AddText(TextEnum.BankTransver, "Bank transver", "Przelew bankowy");
      AddText(TextEnum.PayU, "PayU", "PayU");
      AddText(TextEnum.EnterYourShippingData, "Enter your shipping data", "Wpisz dane do wysyłki");
      AddText(TextEnum.Address, "Address", "Adres");
      AddText(TextEnum.ZipCodeAndCity, "Zip code and city", "kod pocztowy i miejscowść");
      AddText(TextEnum.PhoneNumber, "Phone number", "Numer telefonu");
      AddText(TextEnum.IWantToSendThisPackageToADifferentAddress, "I want to send this package to a different address", "tę przesłkę chcę przesłać na inny adres");
      AddText(TextEnum.IWantToProvideOtherDetailsForTheInvoice, "I want to provide other details for the invoice", "Chcę podać inne dane do faktury");
      AddText(TextEnum.IWantToAddNotesToTheOrder, "I want to add notes to the order", "chcę dodać uwagi do zamówienia");
      AddText(TextEnum.EnterYourCommentsOnTheOrderHere, "Enter your comments on the order here", "Tutaj wpisz swoje uwagi do zamówienia");
      AddText(TextEnum.IAcceptTheTermsAndConditionsOfTheShop, "I accept the terms and conditions of the shop", "Akceptuję regulamin sklepu");
      AddText(TextEnum.IAgreeToIssueAndSendAnInvoiceInElectronicForm, "I agree to issue and send an invoice in electronic form", "Wyrażam zgodę na wystawienie i przesłanie faktury w formie elektronicznej");
      AddText(TextEnum.Citi, "Citi", "Miasto");
      AddText(TextEnum.ZipCode, "Zip code", "Kod pocztowy");
      AddText(TextEnum.TheMethodOfPaymentChosen, "The method of payment chosen", "Wybrany sposób płatność");
      AddText(TextEnum.SelectedDeliveryMethod, "Selected delivery method", "Wybrany spoób dostawy");
      AddText(TextEnum.ShippingData, "Shipping data", "Dane do wysłki");
      AddText(TextEnum.NoDataToDisplay, "No data to display", "Brak danych do wyświetlenia" );
    }

    private void AddText(TextEnum xCntText, string xEN, string xPL) {
      //funkcja dodająca tłumaczenie do kolekcji4
      //xCntText - identyfikator tekstu
      //xEN - tłumaczenie angielskie
      //xPL - tłumaczenie polskie
      //xRUS - tłumaczenie rosyjskie 

      mCln_En.Add(xCntText, xEN);
      mCln_Pl.Add(xCntText, xPL);


    }



  }
}

