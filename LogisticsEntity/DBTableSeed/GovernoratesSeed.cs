using LogisticsDataCore.Tables;
using Microsoft.EntityFrameworkCore;

namespace LogisticsEntity.DBTableSeed
{
    public class DBGovernoratesSeed(ModelBuilder modelBuilder)
    {
        public void SeedGovernorates()
        {
            modelBuilder.Entity<Governorate>().HasData(
                   new Governorate() { GovernorateName = "Alexandria", GovernorateID = 1 },
                   new Governorate() { GovernorateName = "Aswan", GovernorateID = 2 },
                   new Governorate() { GovernorateName = "Asyut", GovernorateID = 3 },
                   new Governorate() { GovernorateName = "Beheira", GovernorateID = 4 },
                   new Governorate() { GovernorateName = "Beni Suef", GovernorateID = 5 },
                   new Governorate() { GovernorateName = "Cairo", GovernorateID = 6 },
                   new Governorate() { GovernorateName = "Dakahlia", GovernorateID = 7 },
                   new Governorate() { GovernorateName = "Damietta", GovernorateID = 8 },
                   new Governorate() { GovernorateName = "Faiyum", GovernorateID = 9 },
                   new Governorate() { GovernorateName = "Gharbia", GovernorateID = 10 },
                   new Governorate() { GovernorateName = "Giza", GovernorateID = 11 },
                   new Governorate() { GovernorateName = "Ismailia", GovernorateID = 12 },
                   new Governorate() { GovernorateName = "Kafr El Sheikh", GovernorateID = 13 },
                   new Governorate() { GovernorateName = "Luxor", GovernorateID = 14 },
                   new Governorate() { GovernorateName = "Matrouh", GovernorateID = 15 },
                   new Governorate() { GovernorateName = "Minya", GovernorateID = 16 },
                   new Governorate() { GovernorateName = "Monufia", GovernorateID = 17 },
                   new Governorate() { GovernorateName = "New Valley", GovernorateID = 18 },
                   new Governorate() { GovernorateName = "North Sinai", GovernorateID = 19 },
                   new Governorate() { GovernorateName = "Port Said", GovernorateID = 20 },
                   new Governorate() { GovernorateName = "Qalyubia", GovernorateID = 21 },
                   new Governorate() { GovernorateName = "Qena", GovernorateID = 22 },
                   new Governorate() { GovernorateName = "Red Sea", GovernorateID = 23 },
                   new Governorate() { GovernorateName = "Sharqia", GovernorateID = 24 },
                   new Governorate() { GovernorateName = "Sohag", GovernorateID = 25 },
                   new Governorate() { GovernorateName = "South Sinai", GovernorateID = 26 },
                   new Governorate() { GovernorateName = "Suez", GovernorateID = 27 }
            );
        }
    }

}
