namespace Paw_Powah.Controllers.api.Common
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using System;
    using System.Threading;
    using System.Collections.Specialized;
    using Quartz.Impl;
    using Quartz;
    using Application.Game.Handlers;
    using System.Diagnostics;
    using Persistence.Context;
    using Domain.Entities.Game.Combat;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IVolatileContext context;
        private readonly IPawContext pawContext;
        public HomeController(IVolatileContext context, IPawContext pawContext)
        {
            this.context = context;
            this.pawContext = pawContext;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    this.pawContext.Kinds.Add(new Kind
            //    {
            //        IncreaseAmount = 1,
            //        IncreaseStatType = "1",
            //        Name = "s",
            //        SpellId = 1,
            //    });
            //}

            //await this.pawContext.SaveChangesAsync(CancellationToken.None);

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCD(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.context.Cooldowns.Add(new Cooldown
                {
                    EndsOn = DateTime.UtcNow.AddSeconds(5),
                    UnitId = 1,
                    SpellId = 1,
                });
            }

            await this.context.SaveChangesAsync(CancellationToken.None);

            return this.Ok();
        }

        public async Task<IActionResult> ClearCD(int repeatCount)
        {
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            IJobDetail job = JobBuilder.Create<VolatileHandler>()
                .WithIdentity("clearCD", "CD")
                .Build();

            var sw = new Stopwatch();
            sw.Start();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("clearCDTrigger", "CD")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithInterval(TimeSpan.FromMilliseconds(10))
                    .WithRepeatCount(repeatCount - 1))
            .Build();

            await sched.ScheduleJob(job, trigger);

            sw.Stop();

            return this.Json(new { sw.ElapsedMilliseconds });
        }
    }
}
