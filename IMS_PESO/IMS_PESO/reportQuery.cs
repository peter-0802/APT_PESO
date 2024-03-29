﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace IMS_PESO
{
    public class reportQuery
    {
        public string graphAll = @"SELECT
                            `DATE`,
                            coalesce(`SRA`, 0) `SRA`,
                            coalesce(`JOB_FAIR`, 0) `JOB_FAIR`,
                            coalesce(`COLLEGE_SCHOOLAR`, 0) `COLLEGE_SCHOOLAR`,
                            coalesce(`HS_SCHOOLAR`, 0) `HS_SCHOOLAR`,
                            coalesce(`OFW`, 0) `OFW`,
                            coalesce(`RWA`, 0) `RWA`,
                            coalesce(`CL`, 0) `CL`,
                            coalesce(`PWD`, 0) `PWD`,
                            coalesce(`SPES`, 0) `SPES`,
                            coalesce(`KAS`, 0) `KAS`,
                            coalesce(`NSRP`, 0) `NSRP`
                            FROM
                              #SELECT ALL YEARS PER MODULE
                              (
                              select DATE_FORMAT(event_date, '%M') `DATE` from sra2
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(event_date, '%M') `DATE` from jobfair2
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from schoolar_coll
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from hsshcoolar
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from ofw2
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from rwa
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(event_date, '%M') `DATE` from child_labor
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from pwd
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(event_date, '%M') `DATE` from spes
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from kasambahay2
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              union all
                              select DATE_FORMAT(date, '%M') `DATE` from contact2
                              where DATE_FORMAT(date, '%Y') = '{0}'
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

                              left join
                              (
                              SELECT
                              DATE_FORMAT(event_date, '%M') `YEAR`,
                              count(*) `JOB_FAIR`
                              FROM jobfair2
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `JOB_FAIR` on `JOB_FAIR`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `COLLEGE_SCHOOLAR`
                              FROM schoolar_coll
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `COLLEGE_SCHOOLAR` on `COLLEGE_SCHOOLAR`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `HS_SCHOOLAR`
                              FROM hsshcoolar
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `HS_SCHOOLAR` on `HS_SCHOOLAR`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `OFW`
                              FROM ofw2
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `OFW` on `OFW`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `RWA`
                              FROM rwa
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `RWA` on `RWA`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(event_date, '%M') `YEAR`,
                              count(*) `CL`
                              FROM child_labor
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `CL` on `CL`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `PWD`
                              FROM PWD
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `PWD` on `PWD`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(event_date, '%M') `YEAR`,
                              count(*) `SPES`
                              FROM spes
                              where DATE_FORMAT(event_date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `SPES` on `SPES`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `KAS`
                              FROM kasambahay2
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `KAS` on `KAS`.`YEAR` = `BASE_DATE`.`DATE`

                              left join
                              (
                              SELECT
                              DATE_FORMAT(date, '%M') `YEAR`,
                              count(*) `NSRP`
                              FROM contact2
                              where DATE_FORMAT(date, '%Y') = '{0}'
                              group by `YEAR`
                              ) `NSRP` on `NSRP`.`YEAR` = `BASE_DATE`.`DATE`
                              #END OF JOIN THE RESPECTIVE COUNTS PER TABLE QUERY


                            group by `DATE`
                            ORDER BY FIELD(`DATE`,'January','February','March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December')";
    }
}
