using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace IMS_PESO
{
    public class reportSpecific
    {
        public string rwa = @"SELECT
                            `DATE`,
                            coalesce(`SRA`, 0) `RWA`
                            FROM
                              #SELECT ALL YEARS PER MODULE
                              (
                              select DATE_FORMAT(date, '%M') `DATE` from rwa
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              ) `BASE_DATE`
                              #END OF SELECT ALL YEARS PER MODULE QUERY

                              #JOIN THE RESPECTIVE COUNTS PER TABLE
                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `SRA`
                              FROM rwa
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `SRA` on `SRA`.`YEAR` = `BASE_DATE`.`DATE`
                              #END OF JOIN THE RESPECTIVE COUNTS PER TABLE QUERY

                            group by `DATE`
                            ORDER BY FIELD(`DATE`,'January','February','March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December')";

        public string sra = @"SELECT
                            `DATE`,
                            coalesce(`SRA`, 0) `SRA`
                            FROM
                              #SELECT ALL YEARS PER MODULE
                              (
                              select DATE_FORMAT(event_date, '%M') `DATE` from sra2
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              ) `BASE_DATE`
                              #END OF SELECT ALL YEARS PER MODULE QUERY

                              #JOIN THE RESPECTIVE COUNTS PER TABLE
                              left join
                              (
                              SELECT
                              DATE_FORMAT(event_date, '%M') `YEAR`,
                              count(*) `SRA`
                              FROM sra2
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `SRA` on `SRA`.`YEAR` = `BASE_DATE`.`DATE`
                              #END OF JOIN THE RESPECTIVE COUNTS PER TABLE QUERY

                            group by `DATE`
                            ORDER BY FIELD(`DATE`,'January','February','March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December')";
    }
}
