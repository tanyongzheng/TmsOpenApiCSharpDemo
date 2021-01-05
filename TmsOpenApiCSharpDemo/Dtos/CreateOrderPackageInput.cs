using System;
using System.Collections.Generic;

namespace TmsOpenApiCSharpDemo.Dtos
{

    public class CreateOrderPackageInput
    {
        /// <summary>
        /// Length
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// VolumeWeight
        /// </summary>
        public decimal? VolumeWeight { get; set; }

        /// <summary>
        /// PriceWeight
        /// </summary>
        public decimal? PriceWeight { get; set; }

        /// <summary>
        /// TrackNo
        /// </summary>
        public string TrackNo { get; set; }

        /// <summary>
        /// LabelUrl
        /// </summary>
        public string LabelUrl { get; set; }

        /// <summary>
        /// 箱运单号,如FBA运单号
        /// </summary>
        public string ParcelShipmentCode { get; set; }

        /// <summary>
        /// 箱号/箱代码
        /// </summary>
        public string ParcelCode { get; set; }

        /// <summary>
        /// 一票多件包裹/箱序号
        /// </summary>
        public int? ParcelNumber { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// InputMemberId
        /// </summary>
        public int? InputMemberId { get; set; }

        /// <summary>
        /// LabelLocalPath
        /// </summary>
        public string LabelLocalPath { get; set; }

        /// <summary>
        /// 对接平台Id
        /// </summary>
        public string ToPlatformId { get; set; }

        /// <summary>
        ///CollectionDate 上网时间
        /// </summary>
        public DateTime? CollectionDate { get; set; }

        /// <summary>
        /// 上网状态
        /// </summary>
        public int? CollectionStatus { get; set; }

        /// <summary>
        ///DeliveryDueDate 签收时间 
        /// </summary>
        public DateTime? DeliveryDueDate { get; set; }

        /// <summary>
        ///DeliveryStatus 签收状态
        /// </summary>
        public int? DeliveryStatus { get; set; }

        /// <summary>
        /// TrackStatus跟踪状态
        /// </summary>
        public int? TrackStatus { get; set; }

        /// <summary>
        ///抓取跟踪最新描述
        /// </summary>
        public string TrackNewestDescription { get; set; }

        /// <summary>
        /// 跟踪抓取最后更新时间
        /// </summary>
        public DateTime? TrackUpdateTime { get; set; }

        /// <summary>
        /// OrderDetail
        /// </summary>
        public List<CreateOrderDetailInput> OrderDetails { get; set; }
    }
}