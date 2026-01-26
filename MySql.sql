SELECT * FROM tbl_sales ORDER BY id;
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

-- Update tbl_sales_lines
-- set remark = 'BUDI'
-- where item_id = 2 and sales_id = 2

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

-- Sales Header 

SELECT
    s.id           AS sales_id,
    s.createdAt    AS created_at,
    s.invoiceNo    AS invoice_no,
    s.cashierName  AS cashier_name,
    s.customerName AS customer_name,
    s.mode         AS MODE,
    s.subtotal     AS subtotal,
    s.tax1Amount   AS tax_amount,
    s.serviceChargeAmount AS service_charge,
    s.total        AS total,
    s.status       AS STATUS
FROM tbl_sales s
WHERE s.created >= @FROM
  AND s.created <= @TO
  AND (
        @kw = '' OR
        s.invoiceNo LIKE CONCAT('%', @kw, '%') OR
        s.cashierName LIKE CONCAT('%', @kw, '%') OR
        s.customerName LIKE CONCAT('%', @kw, '%') OR
        s.notes LIKE CONCAT('%', @kw, '%')
      )
ORDER BY s.id DESC;


-- Sales Detail 
SELECT * FROM tbl_sales_lines;
SELECT * FROM tbl_items;

SELECT
    l.sales_id,
    l.id          AS line_id,
    l.item_id,
    l.description    AS item_name,
    l.quantity    AS qty,
    l.unitPrice   AS price,
    l.remark      AS remark,
    i.duration    AS duration,
    i.tolerance   AS tolerance,
    c.id          AS category_id,
    c.name        AS category_name
FROM tbl_sales_lines l
LEFT JOIN tbl_items i       ON i.id = l.item_id
LEFT JOIN tbl_categories c  ON c.id = i.category_id
WHERE l.sales_id = 2
  AND l.item_id IS NOT NULL
  AND (l.type = 1 OR l.type IS NULL)
  AND c.id = 9
ORDER BY l.idx ASC, l.id ASC;
