﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Services {

    public class DatabaseRegisteredUsersService : IRegisteredUsersService {

        private readonly AdvancedProgrammingProjectsServerContext _context;

        public DatabaseRegisteredUsersService(AdvancedProgrammingProjectsServerContext context) {

            this._context = context;

        }

        public async Task<bool> doesUserExists(string? username) {
            if (username == null) {
                return false;
            }
            if (await this.GetRegisteredUser(username) == null) {
                return false;
            }
            return true;
        }

        public async Task<RegisteredUser?> GetRegisteredUser(string? username) {
            if (username == null) {
                return null;
            }
            RegisteredUser? user = await _context.RegisteredUser.Where(ru => ru.username == username).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool?> editDescription(string? username, string? newDescription)
        {
            if (username == null || newDescription == null)
            {
                return false;
            }
            RegisteredUser? user = await this.GetRegisteredUser(username);
            user.description = newDescription;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> getDescription(string? username)
        {
            if (username == null)
            {
                return null;
            }
            RegisteredUser? user = await this.GetRegisteredUser(username);
            if (user == null)
            {
                return null;
            }
            return user.description;
        }

        public string? generateNickNum(){
            string nickNum = string.Empty;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int number = rand.Next(0, 10);
                nickNum = nickNum + number;
            }
            return nickNum;
        }

        public async Task<string?> getNickNum(string? username)
        {
            if (username == null)
            {
                return null;
            }
            RegisteredUser? user = await this.GetRegisteredUser(username);
            if(user == null)
            {
                return null;
            }
            return user.nickname;
        }

        public async Task<string?> getNickname(string? username)
        {
            if (username == null)
            {
                return null;
            }
            string? nickname = await (from user in _context.RegisteredUser
                                      where user.username == username
                                      select user.nickname).FirstOrDefaultAsync();
            return nickname;
        }

        public async Task<bool> editNickName(string? username, string? newNickName)
        {
            if (username == null || newNickName == null)
            {
                return false;
            }
            RegisteredUser user = await this.GetRegisteredUser(username);
            user.nickname = newNickName;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
