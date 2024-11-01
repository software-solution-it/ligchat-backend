﻿using LigChat.Data.Interfaces.IRepositories;
using LigChat.Backend.Web.Extensions.Database;
using LigChat.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LigChat.Data.Repositories
{
    public class MessageSchedulingRepository : IMessageSchedulingRepositoryInterface, IDisposable
    {
        private readonly DatabaseConfiguration _context;

        public MessageSchedulingRepository(DatabaseConfiguration context)
        {
            _context = context;
        }

        public MessageScheduling Save(MessageScheduling messageScheduling)
        {
            _context.MessageSchedulings.Add(messageScheduling);
            _context.SaveChanges();
            return messageScheduling;
        }

        public MessageScheduling Update(int id, MessageScheduling messageScheduling)
        {
            var existingMessageScheduling = _context.MessageSchedulings.Find(id);

            if (existingMessageScheduling != null)
            {
                existingMessageScheduling.MessageText = messageScheduling.MessageText;
                existingMessageScheduling.FlowId = messageScheduling.FlowId;
                existingMessageScheduling.SectorId = messageScheduling.SectorId;
                existingMessageScheduling.SendDate = messageScheduling.SendDate;
                existingMessageScheduling.Tags = messageScheduling.Tags;
                existingMessageScheduling.UpdatedAt = DateTime.UtcNow;

                _context.SaveChanges();
                return existingMessageScheduling;
            }

            return null;
        }

        public MessageScheduling Delete(int id)
        {
            var messageScheduling = _context.MessageSchedulings.Find(id);

            if (messageScheduling != null)
            {
                _context.MessageSchedulings.Remove(messageScheduling);
                _context.SaveChanges();
                return messageScheduling;
            }

            return null;
        }

        public MessageScheduling? GetById(int id)
        {
            return _context.MessageSchedulings.Find(id);
        }

        public IEnumerable<MessageScheduling> GetBySendDate(string sendDate)
        {
            return _context.MessageSchedulings.Where(ms => ms.SendDate == sendDate).ToList();
        }

        public IEnumerable<MessageScheduling> GetAll(int sectorId)
        {
            // Filtra as mensagens agendadas pelo sectorId
            return _context.MessageSchedulings
                           .Where(ms => ms.SectorId == sectorId) // Adiciona a condição de filtro
                           .ToList();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
