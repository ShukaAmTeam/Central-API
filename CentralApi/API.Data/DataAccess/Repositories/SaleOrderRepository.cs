using System;
using System.Linq;
using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess.Repositories
{
    public class SaleOrderRepository : Repository<Products>, IOrderRepository
    {
        /// <exception cref="ArgumentNullException"><paramref name="context" /> is <see langword="null" />.</exception>
        public SaleOrderRepository(CentralDbEntities context)
            : base(context)
        {
            context.UnitMeasures.AddRange(new UnitMeasures[]
              {
                    new UnitMeasures {UnitMeasureCode = "IN", Name = "Inch"},
                    new UnitMeasures {UnitMeasureCode = "KG", Name = "Kilogram"},
                    new UnitMeasures {UnitMeasureCode = "KGV", Name = "Kilogram/cubic meter"},
                    new UnitMeasures {UnitMeasureCode = "KM", Name = "Kilometer"},
                    new UnitMeasures {UnitMeasureCode = "KT", Name = "Kiloton"},
                    new UnitMeasures {UnitMeasureCode = "L", Name = "Liter"},
                    new UnitMeasures {UnitMeasureCode = "M", Name = "Meter"},
                    new UnitMeasures {UnitMeasureCode = "M2", Name = "Square meter"},
                    new UnitMeasures {UnitMeasureCode = "M3", Name = "Cubic meter"},
                    new UnitMeasures {UnitMeasureCode = "MG", Name = "Milligram"},
                    new UnitMeasures {UnitMeasureCode = "ML", Name = "Milliliter"},
                    new UnitMeasures {UnitMeasureCode = "MM", Name = "Millimeter"},
                    new UnitMeasures {UnitMeasureCode = "PC", Name = "Piece"}
              });
        }

        public CentralDbEntities CentralDbContext => DbContext as CentralDbEntities;

        public IEnumerable<SaleOrders> GetSaleOrders(int pageIndex, int pageSize)
        {
            return CentralDbContext
                .SaleOrders
                .Skip((pageIndex - 1)*pageSize)
                .Take(pageSize);
        }

        public IEnumerable<SaleOrders> GetTopSaleOrders(int count)
        {
            return CentralDbContext
                .SaleOrders
                .Take(count);
        }
    }
}