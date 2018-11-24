﻿using BikeStore.Infrastructure.Commands;
using BikeStore.Infrastructure.Commands.Users;
using BikeStore.Infrastructure.Services;
using BikeStore.Infrastructure.Services.Emails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BikeStore.Infrastructure.Handlers.Users {

  class cCreateUserHandler : ICommandHandler<CreateUser> {

      private readonly IUserService mUserService;
      private readonly IEmailService mEmailService;

      public cCreateUserHandler(IUserService UserService, IEmailService xEmailService) {

        mUserService = UserService;
        mEmailService = xEmailService;
      }

      public async Task HandleAsync(CreateUser xCommand) {
        bool pIsResult;
        Guid pUserID;

        pUserID = Guid.NewGuid();

        pIsResult = await mUserService.RegisterAsync(pUserID, xCommand.Email, xCommand.Name, xCommand.Surname, xCommand.Password, "User");                   //Dodanie użytkownika 

        if (pIsResult) {                                      //sprawdzenie czy serwis użytkowników dodął nowego użytkownika
          new Thread(() => {                                   //utworzenie nowego wontku
            Thread.CurrentThread.IsBackground = true;
            mEmailService.SendUserAccountConfirmation(xCommand.Email, pUserID); //wywołanie serwisu aby wysłał link potwierdzający 
          }).Start();
        }

      }

    }

  }