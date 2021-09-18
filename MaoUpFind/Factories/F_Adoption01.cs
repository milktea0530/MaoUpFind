using isRock.LineBot;
using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.Factories
{
    public class F_Adoption01
    {
        #region GetMemberInfo 取得會員資料
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="s_id"></param>
        /// <param name="s_type">0:一般, 1:醫院</param>
        /// <returns></returns>
        public void GetMemberInfo(ref VM_Adoption01_Form data, string s_id, string s_type)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            if (s_type.Equals("0"))
            {
                var tempdata = db.一般會員資料.Where(m => m.會員編號.ToString() == s_id).FirstOrDefault();
                data.會員編號 = tempdata.會員編號;
                data.會員暱稱 = tempdata.會員暱稱;
                data.會員電話 = tempdata.會員電話;
            }
            if (s_type.Equals("1"))
            {
                var tempdata = db.醫院會員資料.Where(m => m.會員編號.ToString() == s_id).FirstOrDefault();
                data.會員編號 = tempdata.會員編號;
                data.會員暱稱 = tempdata.醫院名字;
                data.會員電話 = tempdata.醫院電話;
            }
        }
        #endregion

        #region Create 刊登認養
        public VM_Info Create(ref VM_Adoption01_Form data)
        {

            寵物資料 animal = new 寵物資料();
            刊登認養 adoption = new 刊登認養();

            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Info rInfo = new VM_Info();

            // 認養
            var datetime = DateTime.Now;
            var s_date = datetime.ToString("yyyyMMddhhmmss");
            Random rnd = new Random();
            var num = rnd.Next(1, 1000);
            adoption.認養單號 = "A" + s_date + num;
            adoption.認養標題 = data.認養標題;
            adoption.認養狀態 = "0";
            adoption.會員編號 = data.會員編號;
            adoption.會員暱稱 = data.會員暱稱;
            adoption.會員電話 = data.會員電話;
            adoption.寵物所在地點_市 = data.寵物所在地點_市;
            adoption.寵物所在地點_區 = data.寵物所在地點_區;
            adoption.寵物所在地點_全 = data.寵物所在地點_全;
            adoption.刊登原因 = data.刊登原因;
            adoption.備註 = data.備註;
            adoption.結束時間 = data.結束時間;
            adoption.是否結案 = "0";
            adoption.建立時間 = datetime;
            adoption.更新時間 = datetime;

            // 寵物資料
            animal.動物別編號 = data.動物別編號;
            animal.品種編號 = data.品種編號;
            animal.晶片號碼 = data.晶片號碼;
            animal.寵物稱呼 = data.寵物稱呼;
            animal.寵物年紀 = data.寵物年紀;
            animal.寵物性別 = data.寵物性別;
            animal.健康狀況 = data.健康狀況;
            animal.寵物資訊備註 = data.寵物資訊備註;
            animal.附件一 = data.animal.附件一;
            animal.附件二 = data.animal.附件二;
            animal.附件三 = data.animal.附件三;
            animal.建立時間 = datetime;
            animal.更新時間 = datetime;

            try
            {
                db.寵物資料.Add(animal);
                db.SaveChanges();
                adoption.寵物編號 = animal.寵物編號;
                data.adoption.認養單號 = adoption.認養單號;
                data.adoption.認養編號 = adoption.認養編號;
                data.adoption.建立時間 = adoption.建立時間;
                
                db.刊登認養.Add(adoption);
                db.SaveChanges();

                // 執行訊息推播
                if (CDictionary.LINEBOT_OPEN) LineBot(data);
                寄送刊登成功通知(adoption);
                寄送最新通知(adoption);
                rInfo.isSuccess = true;
                rInfo.Msg = "新增資料成功!";
            }

            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "發生錯誤:寫入資料庫發生問題!";
            }
            return rInfo;
        }
        #endregion

        #region 訊息推播
        /// <summary>
        /// 訊息推播
        /// </summary>
        /// <param name="data">要推播的資料</param>
        public void LineBot(VM_Adoption01_Form data)
        {

            string flex = @"
[
{
 ""type"": ""flex"",
  ""altText"": ""您有一則新的認養訊息"",
  ""contents"":
{
  ""type"": ""bubble"",
  ""hero"": {
                ""type"": ""image"",
    ""url"": ""https://i.ibb.co/KVX0XhL/02.png"",
    ""size"": ""full"",
    ""aspectRatio"": ""20:13"",
    ""aspectMode"": ""cover"",
    ""action"": {
                    ""type"": ""uri"",
    ""uri"": ""https://localhost:44364/""
    }
            },
  ""body"": {
                ""type"": ""box"",
    ""layout"": ""vertical"",
    ""contents"": [
      {
                    ""type"": ""text"",
        ""text"": ""最新認養資訊"",
        ""weight"": ""bold"",
        ""size"": ""xl"",
        ""style"": ""normal""
      },
      {
                    ""type"": ""box"",
        ""layout"": ""vertical"",
        ""margin"": ""lg"",
        ""spacing"": ""sm"",
        ""contents"": [
          {
                        ""type"": ""box"",
            ""layout"": ""baseline"",
            ""spacing"": ""sm"",
            ""contents"": [
              {
                            ""type"": ""text"",
                ""text"": ""標題"",
                ""color"": ""#aaaaaa"",
                ""size"": ""md"",
                ""flex"": 1
              },
              {
                            ""type"": ""text"",
                ""text"": ""--------取代標題--------"",
                ""wrap"": true,
                ""color"": ""#666666"",
                ""size"": ""sm"",
                ""flex"": 5,
                ""align"": ""start""
              }
            ],
            ""margin"": ""none""
          },
          {
                        ""type"": ""box"",
            ""layout"": ""baseline"",
            ""spacing"": ""sm"",
            ""contents"": [
              {
                            ""type"": ""text"",
                ""text"": ""地點"",
                ""color"": ""#aaaaaa"",
                ""size"": ""md"",
                ""flex"": 1
              },
              {
                            ""type"": ""text"",
                ""text"": ""--------取代地點--------"",
                ""wrap"": true,
                ""color"": ""#666666"",
                ""size"": ""sm"",
                ""flex"": 5
              }
            ],
            ""margin"": ""md""
          },
          {
                        ""type"": ""box"",
            ""layout"": ""baseline"",
            ""contents"": [
              {
                            ""type"": ""text"",
                ""text"": ""時間"",
                ""flex"": 1,
                ""size"": ""md"",
                ""color"": ""#aaaaaa""
              },
              {
                            ""type"": ""text"",
                ""text"": ""--------取代時間--------"",
                ""flex"": 5,
                ""size"": ""sm"",
                ""color"": ""#666666"",
                ""align"": ""start"",
                ""wrap"": true
              }
            ],
            ""spacing"": ""sm"",
            ""margin"": ""md""
          }
        ]
      }
    ]
  },
  ""footer"": {
                ""type"": ""box"",
    ""layout"": ""vertical"",
    ""spacing"": ""sm"",
    ""contents"": [
      {
                    ""type"": ""button"",
        ""style"": ""link"",
        ""height"": ""sm"",
        ""action"": {
                        ""type"": ""uri"",
          ""label"": ""詳細資料"",
          ""uri"": ""--------詳細資料--------""
        }
                }
    ],
    ""flex"": 0
  }
        }
    }
]
";
            //flex = flex.Replace("--------取代圖片--------", "https://drive.google.com/uc?export=view&id=1L0q9Z0fTUmtVlPgiobOlEy8KTTRZvuKY.png");
            flex = flex.Replace("--------取代標題--------", data.認養標題);
            flex = flex.Replace("--------取代地點--------", data.寵物所在地點_全);
            flex = flex.Replace("--------取代時間--------", data.adoption.建立時間.ToString());
            flex = flex.Replace("--------詳細資料--------", "https://localhost:44364/Adoption02/detailView?number=" + data.adoption.認養單號);
            // 應該要取得userID並寫入資料庫, 到時候從資料庫取得
            var bot = new Bot(CDictionary.LINEBOT_ChannelAccessToken);
            var arr_user = CDictionary.LINEBOT_USER_ID.Split(',');
            foreach (var user in arr_user)
            {
                bot.PushMessageWithJSON(user, flex);
            }
        }
        #endregion

        #region 寄送刊登成功通知(寄給刊登人)
        /// <summary>
        /// 寄送刊登成功通知(寄給刊登人)
        /// </summary>
        /// <param name="data"></param>
        public void 寄送刊登成功通知(刊登認養 adoption)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Mail m_Mail = new VM_Mail();
            // 取得會員的mail(找不到mail就不寄信)
            var user = db.會員檢視表.Where(m => m.會員編號 == adoption.會員編號).FirstOrDefault();
            if (user.會員信箱 == null) return;
            m_Mail.M_Address = user.會員信箱;
            string url = "https://localhost:44364/Adoption02/detailView?number=" + adoption.認養單號;
            // 信件標題
            m_Mail.M_Subject = "刊登認養通知";
            // 信件內容
            m_Mail.M_Body += "<html><body>";
            m_Mail.M_Body += $"<p>您好 {user.會員帳號},您已成功刊登認養</p>";
            m_Mail.M_Body += $"<p>認養單號: <span style='color:blue'>{adoption.認養單號}</span></p>";
            m_Mail.M_Body += $"<p>刊登時間: {adoption.建立時間}</p>";
            m_Mail.M_Body += $"<p><a href='{url}'>點我可直接進查詢專欄</a></p>";
            m_Mail.M_Body += "</body></html>";
            (new F_SendEmail()).send(m_Mail);
        }
        #endregion

        #region 寄送最新通知(寄給符合地區的會員)
        /// <summary>
        /// 寄送最新通知(寄給符合地區的會員)
        /// </summary>
        /// <param name="data"></param>
        public void 寄送最新通知(刊登認養 adoption)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Mail m_Mail = new VM_Mail();
            // 取得所有符合地區的會員資料,設定可收到通知,排除刊登人
            var users = db.會員檢視表.Where(m => m.收到通知 == "1"
                                                && m.會員帳號 != adoption.會員編號.ToString()
                ).ToList();
            if (users.Count <= 0) return;
            string url = "https://localhost:44364/Adoption02/detailView?number=" + adoption.認養單號;
            // 信件標題
            m_Mail.M_Subject = "最新認養資訊";
            // 信件內容
            m_Mail.M_Body += "<html><body>";
            m_Mail.M_Body += $"<p>您好 --取代會員帳號--</p>";
            m_Mail.M_Body += $"<p>現在有最新的寵物認養資訊</p>";
            m_Mail.M_Body += $"<p><a href='{url}'>點我可直接查看詳細資料</a></p>";
            m_Mail.M_Body += "</body></html>";
            // 寄信
            foreach (var user in users)
            {
                // 判斷是否有信箱
                if (string.IsNullOrEmpty(user.會員信箱)) continue;
                m_Mail.M_Body = m_Mail.M_Body.Replace("--取代會員帳號--", user.會員帳號);
                m_Mail.M_Address = user.會員信箱;
                (new F_SendEmail()).send(m_Mail);
            }
        }
        #endregion
    }
}