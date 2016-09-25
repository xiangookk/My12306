using System;
using System.Collections.Generic;
using System.Text;

namespace My12306
{
    class Passenger
    {
        public int index { get; set; }
        public string first_letter { get; set; }
        public string isUserSelf { get; set; }
        public string mobile_no { get; set; }
        public string old_passenger_id_no { get; set; }
        public string old_passenger_id_type_code { get; set; }
        public string old_passenger_name { get; set; }
        public string passenger_flag { get; set; }
        public string passenger_id_no { get; set; }
        public string passenger_id_type_code { get; set; }
        public string passenger_id_type_name { get; set; }
        public string passenger_name { get; set; }
        public string passenger_type { get; set; }
        public string passenger_type_name { get; set; }
        public string recordCount { get; set; }
        /*
            first_letter                "SXX"
            isUserSelf                  ""	
            mobile_no                 "15214322163"	
            old_passenger_id_no   ""	
            old_passenger_id_type_code  ""	
            old_passenger_name        ""	
            passenger_flag          "0"	
            passenger_id_no       "429006198902104513"	
            passenger_id_type_code       "1"	
            passenger_id_type_name      ""
            passenger_name       "孙向向"
            passenger_type        "1"	
            passenger_type_name         ""
            recordCount            "7"
         */

        /*
          {
              "passenger_type_name": "成人",
              "isUserSelf": "N",
              "passenger_id_type_code": "1",
              "passenger_name": "桂秀秀",
              "total_times": "99",
              "passenger_id_type_name": "二代身份证",
              "passenger_type": "1",
              "passenger_id_no": "420821199210110086",
              "mobile_no": ""
            }
          {
            "code":"11",
            "passenger_name":"孙向向",
            "sex_code":"M",
            "sex_name":"男",
            "born_date":"1989-02-10 00:00:00",
            "country_code":"CN",
            "passenger_id_type_code":"1",
            "passenger_id_type_name":"二代身份证",
            "passenger_id_no":"429006198902104513",
            "passenger_type":"1",
            "passenger_flag":"0","passenger_type_name":"成人",
            "mobile_no":"15214322163",
            "phone_no":"",
            "email":"276915081@qq.com",
            "address":"","postalcode":"",
            "first_letter":"SXX",
            "recordCount":"50",
            "isUserSelf":"Y",
            "total_times":"99"
            }
         */
    }
}
