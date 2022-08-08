using System.Text;

namespace Select_HtmlToPdf_NetCore.Utility
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(string membershipNo, string date, string fullName, 
	    string district, string mandalam, string panchayath, string emirate, string area, string collectedBy )
        {  
            var sb = new StringBuilder();
            sb.Append(@"<html>
                        <head>
                        <style>
                        body {
                            background-color: white;
                            font-family:'verdana';
                        }
                        .id-card-holder {
                            width: 500px;
                            padding: 4px;
                            margin: 0 auto;
                            background-color: #00FF00;
                            border-radius: 5px;
                            position: relative;
                        }
                        .id-card-holder:after {
                            content: '';
                            width: 7px;
                            display: block;
                            background-color: #0a0a0a;
                            height: 100px;
                            position: absolute;
                            top: 105px;
                            border-radius: 0 5px 5px 0;
                        }
                        .id-card-holder:before {
                            content: '';
                            width: 7px;
                            display: block;
                            background-color: #0a0a0a;
                            height: 100px;
                            position: absolute;
                            top: 105px;
                            left: 498px;
                            border-radius: 5px 0 0 5px;
                        }
                        .id-card {

                            background-color: #fff;
                            padding: 10px;
                            border-radius: 10px;
                            text-align: center;
                            box-shadow: 0 0 1.5px 0px #b9b9b9;
                        }
                        .id-card img {
                            margin: 0 auto;
                        }
                        .header img {
                            width: 480px;
                            margin-top: 15px;
                        }
                        .photo img {
                            width: 80px;
                            margin-top: 15px;
                        }
                        h2 {
                            font-size: 20px;
                            margin: 5px 0;
                        }
                        h3 {
                            font-size: 16px;
                            margin: 2.5px 0;
                            font-weight: 300;
                        }
                        .qr-code img {
                            width: 50px;
                        }
                        p {
                            font-size: 14px;
                            margin: 2px;
                        }
                        .id-card-hook {
                            background-color: #000;
                            width: 70px;
                            margin: 0 auto;
                            height: 15px;
                            border-radius: 5px 5px 0 0;
                        }
                        .id-card-hook:after {
                            content: '';
                            background-color: #d7d6d3;
                            width: 47px;
                            height: 6px;
                            display: block;
                            margin: 0px auto;
                            position: relative;
                            top: 6px;
                            border-radius: 4px;
                        }
                        .id-card-tag-strip {
                            width: 45px;
                            height: 40px;
                            background-color: #0950ef;
                            margin: 0 auto;
                            border-radius: 5px;
                            position: relative;
                            top: 9px;
                            z-index: 1;
                            border: 1px solid #0041ad;
                        }
                        .id-card-tag-strip:after {
                            content: '';
                            display: block;
                            width: 100%;
                            height: 1px;
                            background-color: #c1c1c1;
                            position: relative;
                            top: 10px;
                        }
                        .id-card-tag {
                            width: 0;
                            height: 0;
                            border-left: 100px solid transparent;
                            border-right: 100px solid transparent;
                            border-top: 100px solid #0958db;
                            margin: -10px auto -30px auto;
                        }
                        .id-card-tag:after {
                            content: '';
                            display: block;
                            width: 0;
                            height: 0;
                            border-left: 50px solid transparent;
                            border-right: 50px solid transparent;
                            border-top: 100px solid #d7d6d3;
                            margin: -10px auto -30px auto;
                            position: relative;
                            top: -130px;
                            left: -50px;
                        }
                        </style>
                        </head>");
            sb.AppendLine(@$"<body>
                            <div class='id-card-holder'>
                                <div class='id-card'>
                                    <div class='header'>
                                        <img src='http://member.uaekmcc.com/_next/image?url=%2Fimages%2Fmembership_card_header.png&w=128&q=75'>
                                    </div>
                                    <div class='photo'>
                                    </div>
                                    <h2>Name : {fullName}</h2>
                                    <div class='qr-code'>
                                    </div>
                                    <h3>Membership No : <strong> {membershipNo}</strong></h3>
                                    <hr>
                                    <p>Registration Date : {date}<p>
                                    <p>District {district}</p>
                                    <p>Mandalam {mandalam}</p>
                                    <p>Municipality/Panchayath {panchayath}</p>
                                    <p>Emirates {emirate}, Area {area}</p>
                                    <p>Agent : {collectedBy}</p>
                                </div>
                            </div>
                        </body>
                    </html>");
            return sb.ToString();
        }
    }
}