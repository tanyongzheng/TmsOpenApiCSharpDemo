using System;

namespace TmsOpenApiCSharpDemo.Dtos
{

    public class CreateOrderDetailInput
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// PackageType
        /// </summary>
        public int? PackageType { get; set; }


        /// <summary>
        /// ReferNo
        /// </summary>
        public string ReferNo { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string CnDesc { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnDesc { get; set; }

        /// <summary>
        /// 海关编码
        /// </summary>

        public string CustomcCode { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public decimal? SalesPrice { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal? CostPrice { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int? ProductCount { get; set; }

        /// <summary>
        /// 物品明细重量
        /// </summary>

        public decimal? ProductWeight { get; set; }

        /// <summary>
        /// 产地
        /// </summary>

        public string ProductArea { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>

        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Status
        /// </summary>

        public int? Status { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>

        public int? IsDeleted { get; set; }


        /// <summary>
        /// MainMaterial
        /// </summary>

        public string MainMaterial { get; set; }


        /// <summary>
        /// BatteryCode
        /// </summary>

        public string BatteryCode { get; set; }


        /// <summary>
        /// BrandName
        /// </summary>

        public string BrandName { get; set; }

        /// <summary>
        /// HasBrand
        /// </summary>

        public int? HasBrand { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>

        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 包裹序列号（一票多件用）
        /// </summary>

        public int? ParcelNumber { get; set; }

        /// <summary>
        /// 产品用途Usage
        /// </summary>

        public string Usage { get; set; }

        /// <summary>
        /// 电商链接地址
        /// </summary>
        public string ECommerceUrl { get; set; }

        /// <summary>
        /// 箱运单号,如FBA运单号
        /// </summary>

        public string ParcelShipmentCode { get; set; }
    }
}