SELECT * FROM tbl_sales ORDER BY sales_id;
SELECT * FROM tbl_sales_lines ORDER BY sales_id;

SELECT * FROM tbl_categories;
SELECT * FROM tbl_items;

-- UPDATE tbl_items
-- SET Duration = 1
-- WHERE `code` = 'PG0001';
-- 
-- UPDATE tbl_items
-- SET Duration = 2
-- WHERE `code` = 'PG0002';



SELECT VERSION();
SHOW VARIABLES LIKE 'lower_case_table_names';



SELECT
    i.id                          AS item_id,
    i.code                        AS item_code,
    i.plu                         AS plu,
    i.name                        AS item_name,
    i.name2                       AS item_name_2,
    i.duration 			  AS WaktuBermain,
    i.category_id,
    c.code                        AS category_code,
    c.name                        AS category_name,
    c.department_id,

    i.price1                      AS price,
    i.price2,
    i.price3,
    i.price4,
    i.price5,
    i.price6,

    i.active,
    i.openPrice,
    i.stocked,

    i.tax1,
    i.tax2,
    i.tax3,

    i.printer1_id,
    i.salesWarehouse_id,

    i.created,
    i.updated
FROM tbl_items i
LEFT JOIN tbl_categories c
       ON c.id = i.category_id
WHERE i.active = 1
ORDER BY c.name, i.name;

SELECT * FROM tbl_items;
-- POS Menu Version
SELECT
    i.id          AS item_id,
    i.code,
    i.name,
    c.id 	  AS category_id,
    c.name        AS category,
    i.price1      AS price, 
    i.duration    AS WaktuBermain
    
FROM tbl_items i
JOIN tbl_categories c ON c.id = i.category_id
WHERE i.active = 1
  AND i.price1 > 0
  AND i.type = 0
  AND (c.id = 5 OR c.`id` = 9)
ORDER BY c.priority, c.name, i.name; 




-- Inventory Menu Version
SELECT
    i.id,
    i.code,
    i.name,
    i.stocked,
    i.inventoryToRecipeConversion,
    i.parLevel,
    i.warningLevel,
    i.salesWarehouse_id
FROM tbl_items i
WHERE i.stocked = 1
ORDER BY i.name;


