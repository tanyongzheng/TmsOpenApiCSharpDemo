using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using TmsOpenApiCSharpDemo.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TmsOpenApiCSharpDemo.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            CurrentApiMethodType = ApiMethodTypeList[0];

            this.GenerateJsonCommand = new RelayCommand<object>(GenerateJson);
            this.SendDataCommand = new RelayCommand<object>(SendData);
            this.ClearReceivedDataCommand = new RelayCommand<object>(ClearReceivedData);
            this.ClearRequestDataCommand = new RelayCommand<object>(ClearRequestData);
            var checkAddressInput=new CheckAddressInput();
            checkAddressInput.ChannelCode = "USPSABC1";
            checkAddressInput.ToName = "Mr Lee";
            checkAddressInput.ToCompany = "";
            checkAddressInput.ToContact = "13800138000";
            checkAddressInput.ToCountryCode = "US";
            checkAddressInput.ToCity = "Naples";
            checkAddressInput.ToProvince = "FL";
            checkAddressInput.ToPostCode = "34105";
            checkAddressInput.ToAddress1 = "6859 Del Mar Terrace";
            checkAddressInput.ToAddress2 = "";
            var options = new JsonSerializerOptions() { IgnoreNullValues = true, WriteIndented = true, AllowTrailingCommas = true };
            ApiMethodTypeList[5].MockData= JsonSerializer.Serialize(checkAddressInput, options);

            var createOrderInput=new CreateOrderMainInput();
            createOrderInput.ReferCode = "Test123456789";
            createOrderInput.ChannelCode = "USPSABC1";
            createOrderInput.ToName = "Mr Lee";
            createOrderInput.ToCompany = "Test Company";
            createOrderInput.ToContact = "13800138000";
            createOrderInput.ToCountryName = "US";
            createOrderInput.ToCity = "Naples";
            createOrderInput.ToProvince = "FL";
            createOrderInput.ToPostCode = "34105";
            createOrderInput.ToAddress1 = "6859 Del Mar Terrace";
            createOrderInput.ToAddress2 = "";
            createOrderInput.Weight = 0.345M;
            createOrderInput.OrderPackages=new List<CreateOrderPackageInput>();

            var orderpackage=new CreateOrderPackageInput();
            orderpackage.Length = 2;
            orderpackage.Width = 3;
            orderpackage.Height = 4;
            orderpackage.Weight = 0.345M;
            orderpackage.Count = 1;
            orderpackage.ParcelCode = "A11111111111";
            orderpackage.OrderDetails=new List<CreateOrderDetailInput>();
            
            var orderDetail1=new CreateOrderDetailInput();
            orderDetail1.ReferNo = "SKU001";
            orderDetail1.CnDesc = "包包";
            orderDetail1.EnDesc = "bag";
            orderDetail1.SalesPrice = 0.123M;
            orderDetail1.CustomcCode = "1111111111";
            orderDetail1.ProductCount = 1;
            orderDetail1.ProductWeight = 0.02M;

            var orderDetail2=new CreateOrderDetailInput();
            orderDetail2.ReferNo = "SKU002";
            orderDetail2.CnDesc = "手机壳";
            orderDetail2.EnDesc = "phone cell";
            orderDetail2.SalesPrice = 0.234M;
            orderDetail2.CustomcCode = "2222222222";
            orderDetail2.ProductCount = 1;
            orderDetail2.ProductWeight = 0.03M;

            orderpackage.OrderDetails.Add(orderDetail1);
            orderpackage.OrderDetails.Add(orderDetail2);

            createOrderInput.OrderPackages.Add(orderpackage);


            ApiMethodTypeList[2].MockData = JsonSerializer.Serialize(createOrderInput, options);
        }

        public int UserId { get; set; } 
        public string ApiKey { get; set; } 

        public List<ApiMethodType> ApiMethodTypeList { get; set; } = new List<ApiMethodType>
        {
            new  ApiMethodType{Name="获取所有国家",Path="Country/GetAll",RequestMethod="Get"},
            new  ApiMethodType{Name="获取所有渠道",Path="Channel/GetAll",RequestMethod="Get"},
            new  ApiMethodType{Name="创建订单",Path="Order/CreateOrder",RequestMethod="Post"},
            new  ApiMethodType{Name="获取跟踪号",Path="Order/GetTrackNo",RequestMethod="Get",MockData = "?code=Test202008250003"},
            new  ApiMethodType{Name="获取标签",Path="Order/GetLabel",RequestMethod="Get",MockData = "?code=Test202008250003"},
            new  ApiMethodType{Name="地址验证",Path="Order/CheckAddress",RequestMethod="Post"},
            //new  ApiMethodType{Name="获取余额",Path="User/GetBalance",RequestMethod="Get"},
        };

        public ApiMethodType CurrentApiMethodType { get; set; } 
        public string ApiBaseUrl { get; set; }

        //public string ApiMethodPath { get; set; }

        public string ApiFullUrl
        {
            get => ApiBaseUrl + this.CurrentApiMethodType.Path;
        }

        public string ResponseData { get; set; }
        public string RequestData { get; set; }
        public string RequestHeardData { get; set; }
        public bool IsBusy { get; set; }
        public string ResponseStatusCode { get; set; }


        public ICommand GenerateJsonCommand { get; set; }
        public ICommand SendDataCommand { get; set; }
        public ICommand ClearReceivedDataCommand { get; set; }
        public ICommand ClearRequestDataCommand { get; set; }

        private void GenerateJson(object parameter)
        {
            RequestData = CurrentApiMethodType.MockData;
        }

        private async void SendData(object parameter)
        {
            var baseUrl = ApiBaseUrl;
            var client = new HttpClient { BaseAddress = new Uri(baseUrl) };
            client.Timeout = TimeSpan.FromSeconds(60);
            if (CurrentApiMethodType.RequestMethod == "Get")
            {
                SignHelper.BuildHttpRequestSinData(client, UserId, ApiKey, "");
            }
            else
            {
                SignHelper.BuildHttpRequestSinData(client, UserId, ApiKey,RequestData);
            }

            foreach (var head in client.DefaultRequestHeaders)
            {
                RequestHeardData += head.Key+":"+ head.Value.First()+ "\n";
            }

            IsBusy = true;
            try
            {
                #region request data

                if (CurrentApiMethodType.RequestMethod == "Get")
                {
                    var urlQueryParam = "";
                    if (!string.IsNullOrEmpty(RequestData))
                    {
                        urlQueryParam = RequestData.StartsWith('?')?RequestData:"?"+RequestData;
                    }
                    HttpResponseMessage response = await client.GetAsync(CurrentApiMethodType.Path+urlQueryParam);
                    ResponseStatusCode = $"{(int)response.StatusCode}({response.StatusCode})"; 
                    response.Content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    response.Content.Headers.ContentType.CharSet = "utf-8";
                    ResponseData = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var content = new StringContent(RequestData);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response =
                        await client.PostAsync(CurrentApiMethodType.Path, content);
                    ResponseStatusCode = $"{(int)response.StatusCode}({response.StatusCode})";
                    response.Content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    response.Content.Headers.ContentType.CharSet = "utf-8";
                    ResponseData = await response.Content.ReadAsStringAsync();
                }
                #endregion
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            IsBusy = false;
        }


        private void ClearReceivedData(object parameter)
        {
            ResponseData = "";
        }
        private void ClearRequestData(object parameter)
        {
            RequestData = "";
        }
    }

    public class ApiMethodType
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public string RequestMethod { get; set; }

        public string MockData { get; set; }
    }

}