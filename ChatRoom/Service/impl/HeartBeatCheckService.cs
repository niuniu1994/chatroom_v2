using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChatRoom.Entity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChatRoom.Service
{
    public class HeartBeatCheckService : IHostedService
    {
        private readonly ILogger _logger;
        private DateTime _dateTime;
        
        public HeartBeatCheckService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HeartBeatCheckService>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("heartBeatCheckService started");
            Task.Run(() =>
            {
                while (true)
                {
                    List<User> userList = WebSocketPool.WebSocketPoolDict.Keys.ToList();

                    for (int i = userList.Count - 1; i >= 0; i--)
                    {
                        Thread.Sleep(100);
                        User user = userList[i];
                        TimeSpan timeSpan = DateTime.Now - user.LastCallTime;

                        if (timeSpan.TotalSeconds > 10)
                        {
                            _logger.LogInformation($"websocket of {user.Uid} has been removed");
                            WebSocketPool.Remove(user);
                        }
                    }
                    Thread.Sleep(10000);
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("heartBeatCheckService stoped");
            return Task.CompletedTask;
        }
    }
}