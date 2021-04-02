using System;
using System.Collections.Generic;

namespace TmsOpenApiCSharpDemo.Dtos
{

    public class CreateOrderMainInput
    {
        /// <summary>
        /// 订单代码,由快飞鱼系统生成
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 客户经理代码
        /// </summary>
        public string ManagerCode { get; set; }

        /// <summary>
        /// 订单参考号,同一账户,不能重复
        /// </summary>
        public string ReferCode { get; set; }

        /// <summary>
        /// 跟踪号, 按渠道产品类型, 部分产品预分配(订单生成即分配)
        /// </summary>
        public string TrackNo { get; set; }

        /// <summary>
        /// 运输方式代码
        /// </summary>
        public string ChannelCode { get; set; }

        /// <summary>
        /// ProviderCode
        /// 对外隐藏该属性
        /// </summary>
        //[JsonIgnore]
        //[HiddenInput]
        internal string ProviderCode { get; set; }

        /// <summary>
        /// 票件数，默认1
        /// </summary>
        public int? BillQTY { get; set; }

        /// <summary>
        /// 预计重量, 单位KG
        /// </summary>
        public decimal? Weight { get; set; }

        #region 发件人信息

        /// <summary>
        /// FromName
        /// </summary>

        public string FromName { get; set; }

        /// <summary>
        /// FromCompany
        /// </summary>

        public string FromCompany { get; set; }

        /// <summary>
        /// FromAddress
        /// </summary>

        public string FromAddress { get; set; }

        /// <summary>
        /// FromTelPhone
        /// </summary>

        public string FromTelPhone { get; set; }

        /// <summary>
        /// FromCountry
        /// </summary>

        public string FromCountry { get; set; }

        /// <summary>
        /// FromProvince
        /// </summary>

        public string FromProvince { get; set; }

        /// <summary>
        /// FromCity
        /// </summary>

        public string FromCity { get; set; }

        /// <summary>
        /// FromPostCode
        /// </summary>

        public string FromPostCode { get; set; }
        #endregion

        #region 收件人信息
        /// <summary>
        /// 收件人国家ID, 请从Country接口获取
        /// </summary>
        public int? ToCountryId { get; set; }

        /// <summary>
        /// 收件人国家名, 支持中文名，英文名，国家代码
        /// </summary>
        public string ToCountryName { get; set; }
        /// <summary>
        /// 收件人邮编
        /// </summary>
        public string ToPostCode { get; set; }

        /// <summary>
        /// 收件人名称
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// 收件人地址1
        /// </summary>
        public string ToAddress1 { get; set; }

        /// <summary>
        /// 收件人地址2
        /// </summary>
        public string ToAddress2 { get; set; }

        /// <summary>
        /// 收件人地址3
        /// </summary>
        public string ToAddress3 { get; set; }

        /// <summary>
        /// 收件人省/洲
        /// </summary>
        public string ToProvince { get; set; }

        /// <summary>
        /// 收件人城市
        /// </summary>
        public string ToCity { get; set; }

        /// <summary>
        /// 收件人公司名称
        /// </summary>
        public string ToCompany { get; set; }

        /// <summary>
        /// 收件人联系信息
        /// </summary>
        public string ToContact { get; set; }

        /// <summary>
        /// 收件仓库编码
        /// </summary>
        public string ToWarehouseCode { get; set; }
        
        /// <summary>
        ///收件人文件，证件类型
        /// 譬如护照，公司营业执照，税号等
        /// 巴西固定为：CPF/CNPJ/PSAAPORT
        /// </summary>
        public string ToDocumentType { get; set; }

        /// <summary>
        ///收件人文件，证件号码
        /// 譬如护照号，公司营业执照号码，税号等
        /// </summary>
        public string ToDocumentNumber { get; set; }
        #endregion

        #region 服务选项设置
        /// <summary>
        /// 是否保险 0否, 1是
        /// </summary>
        public int IsSecure { get; set; }

        /// <summary>
        /// 是否电子签名 0否, 1是
        /// </summary>
        public int IsSign { get; set; }

        /// <summary>
        /// 是否签收服务 0否, 1是
        /// </summary>
        public int IsSignatureRequired { get; set; }

        /// <summary>
        /// 是否退件  0否, 1是
        /// </summary>
        public int IsReject { get; set; }

        /// <summary>
        /// 是否带电池 0否, 1是
        /// </summary>
        public int IsBatery { get; set; }

        public int? Status { get; set; }

        public string Remark { get; set; }
        #endregion

        /// <summary>
        /// 是否验证收件人地址
        /// 默认1开启
        /// </summary>
        public int? IsValidateToAddress { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? DutyPaymentType { get; set; }

        /// <summary>
        /// 海外仓代码
        /// </summary>
        public string OverseaWarehouseCode { get; set; }

        public List<CreateOrderPackageInput> OrderPackages { get; set; }
    }
}