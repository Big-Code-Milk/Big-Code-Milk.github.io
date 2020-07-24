# Linq

## Left Join

```C#
var queryable =
 (
from t3 in Entities.SIGN_FORM_MAIN.AsNoTracking()
join t2 in Entities.PAM_AF_DISABLED.AsNoTracking() on  t3.SIGN_FORM_ID equals t2.SIGN_FORM_ID
join t1 in Entities.PAM_AF_DISABLED_DETAIL.AsNoTracking() on t2.ID equals t1.AF_DISABLED_ID into add from t1 in add.DefaultIfEmpty()
join t4 in Entities.FUNCTION_TYPE.AsNoTracking() on t1.SERVICE_NAME equals t4.ID into ft from t4 in ft.DefaultIfEmpty()
orderby t2.SIGN_FORM_ID descending
select new { t1, t2, t3, t4 }
)
.AsQueryable();
```

## EntityFunctions

```C#
var IF008_EMP_NO =
(from t1 in Repository.Entities.PAM_IF_RESIGN.AsNoTracking()
where EntityFunctions.DiffDays(DateTime.Now, t1.ACCOUNT_CLOSE_DATE) <= 7 &&
EntityFunctions.DiffDays(DateTime.Now, t1.ACCOUNT_CLOSE_DATE) > 0
group t1 by new
{
EMP_NO = t1.EMP_NO,
 } into t1
select new { t1 });
```

## Lamda

```C#
var data =
 Entities.PERSON_PERMISSION
 .Where(x => x.PERSON_ORG_CHANGE_ID ==
(int)i.Id)
.Select(x => x.ACCOUNT.FUNCTION_TYPE)
.ToList();
```

## groupby

<https://yangxinde.pixnet.net/blog/post/31357272>

## not in

<https://dotblogs.com.tw/dc690216/2009/09/13/10601>

```C#
(new int?[] { 1, 2 }).Contains(p.CategoryID)

(new int?[] { 9001, 9002, 9003, 9004, 9005, 9006, 9007, 9008, 9009, 2, 3, 4, 5, 7, 9 }).Contains(x.t2.FUNCTION_TYPE)
```

## IQueryable to String Array 做 not in 比對

```C#
/// 錯誤
string[] IF008_EMP_NO = (from t1 in Repository.Entities.PAM_IF_RESIGN.AsNoTracking()
                                where EntityFunctions.DiffDays(DateTime.Now, t1.ACCOUNT_CLOSE_DATE) <= 7 &&
                                       EntityFunctions.DiffDays(DateTime.Now, t1.ACCOUNT_CLOSE_DATE) > 0
                                group t1 by new
                                {
                                    EMP_NO = t1.EMP_NO,

                                } into t1
                                select new { t1 }).ToArray(); // 7 天內 PAM_IF_RESIGN 新增資料且 IF008 Distinct 確保唯一值 DBSET

// 用了鳥方法成功...

var IF008_EMP_NO = (from t1 in Repository.Entities.PAM_IF_RESIGN.AsNoTracking()
                                where EntityFunctions.DiffDays(DateTime.Now, t1.ACCOUNT_CLOSE_DATE) <= 7 &&
                                       EntityFunctions.DiffDays(DateTime.Now, t1.ACCOUNT_CLOSE_DATE) > 0
                                group t1 by t1.EMP_NO into EMP_NO
                                select new { EMP_NO } ).ToList(); // 7 天內 PAM_IF_RESIGN 新增資料且 IF008 Distinct 確保唯一值 DBSET

            string[] Items = new string[IF008_EMP_NO.Count];
            for (int i = 0; i < IF008_EMP_NO.Count; i++) { Items[i] = IF008_EMP_NO[i].EMP_NO.Key; }


            var SevenDays_List = (from t2 in Repository.Entities.ACCOUNT.AsNoTracking()
                                  where Items.Contains(t2.EMP_NO)
                                  select new { t2 }).ToList(); // 7 天內 Account 新增資料 Group Emp_No 只取一筆

```

<https://stackoverflow.com/questions/2176011/iqueryable-to-string-array/2176044>

## Linq LAMDA groupby

```C#
List<Order> OrderList = viewModel.GroupBy(x => new {
                SoldTime = x.SoldTime.GetValueOrDefault().Date,
                GoodsName = x.GoodsName
            }).Select(x => new Order
            {
                GoodsName = x.Key.GoodsName,
                SoldTime = x.Key.SoldTime,
                Quantity = x.Sum(y => y.Quantity)
            }).ToList();
```

<https://dotblogs.com.tw/noncoder/2019/03/25/Lambda-GroupBy-Sum>
