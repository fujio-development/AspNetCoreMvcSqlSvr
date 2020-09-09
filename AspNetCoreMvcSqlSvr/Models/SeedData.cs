using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreMvcSqlSvr.Data;

namespace AspNetCoreMvcSqlSvr.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcShohinContext(serviceProvider.GetRequiredService<DbContextOptions<MvcShohinContext>>()))
            {
                if (context.Shohin.Any())
                {
                    return; //すでにデータが存在するなら追加しない。
                }

                context.Shohin.AddRange(
                    new Shohin
                    {
                        ShohinCode = 7500,
                        ShohinName = "ｾﾄｳﾁﾚﾓﾝ",
                        EditDate = 20190417,
                        EditTime = 203145,
                        Note = "none"
                    },

                    new Shohin
                    {
                        ShohinCode = 2840,
                        ShohinName = "ﾘﾝｺﾞｼﾞｭｰｽ",
                        EditDate = 20050923,
                        EditTime = 102532,
                        Note = "果汁100%の炭酸飲料です"
                    },

                    new Shohin
                    {
                        ShohinCode = 1580,
                        ShohinName = "ｶﾌｪｵﾚ",
                        EditDate = 20160716,
                        EditTime = 91103,
                        Note = "200ml増量です",
                    },

                    new Shohin
                    {
                        ShohinCode = 270,
                        ShohinName = "ｳﾒｵﾆｷﾞﾘ",
                        EditDate = 20080825,
                        EditTime = 141520,
                        Note = "none"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
