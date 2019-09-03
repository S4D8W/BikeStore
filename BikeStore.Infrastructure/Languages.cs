﻿using BikeStore.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Infrastructure {
 public class Languages {
    public enum LanguageEnum {
      None = 0,
      Poland = 1,
      UK = 2,
    }

    public enum TextEnum {
    }


   

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
      }

      private void AddText(TextEnum xCntText, string xEN, string xPL, string xRUS) {
        //funkcja dodająca tłumaczenie do kolekcji4
        //xCntText - identyfikator tekstu
        //xEN - tłumaczenie angielskie
        //xPL - tłumaczenie polskie
        //xRUS - tłumaczenie rosyjskie 

        mCln_En.Add(xCntText, xEN);
        mCln_Pl.Add(xCntText, xPL);
        mCln_Rus.Add(xCntText, xRUS);

      }



    }
  }

