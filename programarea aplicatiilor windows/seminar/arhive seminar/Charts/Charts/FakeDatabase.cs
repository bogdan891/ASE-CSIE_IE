using Charts.Entities;
using System;
using System.Collections.Generic;

namespace Charts
{
    public static class FakeDatabase
    {
        public static List<Company> Companies = new List<Company>()
        {
            new Company() { Id = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"), Name = "Google" },
            new Company() { Id = Guid.Parse("A0C26CC1-202F-487E-A106-4EF9D8C45CC5"), Name = "OpenAI"}
        };

        public static List<Stock> Stocks = new List<Stock>() {
            new Stock() {
                CompanyId = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"),
                Date = DateTime.Now.AddDays(-5),
                Open = 59,
                Close = 72,
                Low = 51,
                High = 76
            },
            new Stock() {
                CompanyId = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"),
                Date = DateTime.Now.AddDays(-4),
                Open = 72,
                Close = 81,
                Low = 72,
                High = 102
            },
            new Stock() {
                CompanyId = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"),
                Date = DateTime.Now.AddDays(-3),
                Open = 81,
                Close = 63,
                Low = 41,
                High = 83
            },
            new Stock() {
                CompanyId = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"),
                Date = DateTime.Now.AddDays(-2),
                Open = 63,
                Close = 53,
                Low = 24,
                High = 68
            },
            new Stock() {
                CompanyId = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"),
                Date = DateTime.Now.AddDays(-1),
                Open = 53,
                Close = 59,
                Low = 48,
                High = 67
            },
            new Stock() {
                CompanyId = Guid.Parse("D8B71379-F337-4C3E-88C4-77A63EBD9765"),
                Date = DateTime.Now,
                Open = 59,
                Close = 103,
                Low = 59,
                High = 103
            },
            new Stock() {
                CompanyId = Guid.Parse("A0C26CC1-202F-487E-A106-4EF9D8C45CC5"),
                Date = DateTime.Now.AddDays(-1),
                Open = 592,
                Close = 603,
                Low = 588,
                High = 621
            },
            new Stock() {
                CompanyId = Guid.Parse("A0C26CC1-202F-487E-A106-4EF9D8C45CC5"),
                Date = DateTime.Now,
                Open = 603,
                Close = 561,
                Low = 518,
                High = 640
            }
        };
    }
}
