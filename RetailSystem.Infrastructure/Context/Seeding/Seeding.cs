﻿using Microsoft.EntityFrameworkCore;
using RetailSystem.Domain.Models;

namespace RetailSystem.Infrastructure.Context.Seeding
{
    public static class Seeding 
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { ID = 1, CityName = "القاهرة - مدينة نصر" },
                new City { ID = 2, CityName = "القاهرة - القاهرة الجديدة" },
                new City { ID = 3, CityName = "القاهرة - الشروق" },
                new City { ID = 4, CityName = "القاهرة - العبور" },
                new City { ID = 5, CityName = "الاسكندرية - سموحة" }
                );
        }

        public static void SeedBranchs(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().HasData(
                new Branch { ID = 2, BranchName = "فرع الحي السابع", CityID = 1 },
                new Branch { ID = 3, BranchName = "فرع عباس العقاد", CityID = 1 },
                new Branch { ID = 4, BranchName = "فرع التجمع الاول", CityID = 2 },
                new Branch { ID = 5, BranchName = "فرع سموحه", CityID = 5 },
                new Branch { ID = 6, BranchName = "فرع الشروق", CityID = 3 },
                new Branch { ID = 7, BranchName = "فرع العبور", CityID = 4 }
                );
        }

        public static void SeedCashiers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cashier>().HasData(
                new Cashier { ID = 1, CashierName = "محمد احمد", BranchID = 2 },
                new Cashier { ID = 2, CashierName = "محمود احمد محمد", BranchID = 3 },
                new Cashier { ID = 3, CashierName = "مصطفي عبد السميع", BranchID = 2 },
                new Cashier { ID = 4, CashierName = "احمد عبد الرحمن", BranchID = 6 },
                new Cashier { ID = 5, CashierName = "ساره عبد الله", BranchID = 4 }
                );
        }

        public static void SeedInvoicesHeader(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceHeader>().HasData(
                new InvoiceHeader
                {
                    ID = 2,
                    CustomerName = "محمد عبد الله",
                    Invoicedate = new DateTime(2022, 02, 22),
                    CashierID = 1,
                    BranchID = 2
                },
                new InvoiceHeader
                {
                    ID = 3,
                    CustomerName = "محمود احمد",
                    Invoicedate = new DateTime(2022, 02, 23),
                    CashierID = 2,
                    BranchID = 3
                }
                );
        }

        public static void SeedInvoicesDetails(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>().HasData(
                new InvoiceDetail { ID = 2, InvoiceHeaderID = 2, ItemName = "بيبسي 1 لتر", ItemCount = 2, ItemPrice = 20 },
                new InvoiceDetail { ID = 3, InvoiceHeaderID = 2, ItemName = "ساندوتش برجر", ItemCount = 2, ItemPrice = 50 },
                new InvoiceDetail { ID = 4, InvoiceHeaderID = 2, ItemName = "ايس كريم", ItemCount = 1, ItemPrice = 10 },
                new InvoiceDetail { ID = 6, InvoiceHeaderID = 3, ItemName = "سفن اب كانز", ItemCount = 1, ItemPrice = 5 }
                );
        }
    }
}
