SELECT * FROM tbl_sales WHERE id = 6 ORDER BY id;
SELECT * FROM tbl_sales_lines WHERE sales_id = 6 ORDER BY sales_id;

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
SELECT * FROM tbl_items;

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
  AND (c.`id` = 5 OR c.`id` = 9)
ORDER BY c.priority, c.name, i.name; 
-- 
-- update tbl_items set `category_id` = 9 where `code` = 'PG0004'

-- Insert tbl_items 

-- INSERT INTO tbl_items
-- (
--     `active`,
--     `checker`,
--     `code`,
--     `name`,
--     `price1`,
--     `sales`,
--     `stocked`,
--     `saved`,
--     `updated`
-- )
-- VALUES
-- (
--     1,
--     1,
--     'PG0003',
--     'SANKSI KETERLAMBATAN',
--     20000,
--     1,
--     0,
--     NOW(),
--     NOW()
-- );
-- 
-- UPDATE TBL_ITEMS
-- SET
--     `ACTIVE`  = 1,
--     `CHECKER` = 1,
--     `DISCOUNTABLE` = 1,
--     `DURATION` = 0,
--     `INCLUSIVE` = 1,
--     `INVENTORYTORECIPECONVERSION` = 1,
--     `MINIMUMTIME` = 0,
--     `NAME` = 'Kaos Kaki',
--     `OPENITEM` = 0,
--     `OPENPRICE` = 0,
--     `OPENQUANTITY` = 0,
--     `OVERHEAD` = 0,
--     `PARLEVEL` = 0,
--     `PRICE1` = 10000,
--     `PRINTRECEIPT` = 1,
--     `PRODUCTION` = 0,
--     `PURCHASETOINVENTORYCONVERSION` = 1,
--     `PURCHASED` = 0,
--     `RENTAL` = 0,
--     `SALES` = 1,
--     `SERVICECHARGE` = 1,
--     `STOCKED` = 0,
--     `TYPE` = 3,
--     `WARNINGLEVEL` = 0,
--     `MODIFIER` = 0,
--     `FONTSIZE` = 5,
--     `KITCHENDISPLAY` = 0,
--     `COMBO` = 0,
--     `LOCKED` = 0,
--     `NOREPORT` = 0,
--     `AUTOTIMER` = 0,
--     `COUNTDOWN` = 0,
--     `COUNTER` = 0,
--     `STAMPSCREDIT` = 0,
--     `COURSESEPARATOR` = 0,
--     `INTERCHANGE` = 0,
--     `ZEROPRICEMODIFIER` = 0,
--     `PRICE2` = 0,
--     `PRICE3` = 0,
--     `PRICE4` = 0,
--     `PRICE5` = 0,
--     `PRICE6` = 0,
--     `UPDATED` = NOW()
-- WHERE `CODE` = 'PG0003';
-- 


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
SELECT * FROM tbl_sales;
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

-- -- SIMULATE A TRANSACTION QUERY 
-- 
-- -- =========================
-- -- Choose which item to sell
-- -- =========================
-- SET @item_code := 'PG0002';   -- change to 'PG0002' if needed
-- 
-- -- Pick a template sale row to clone (any existing sale id is fine)
-- SET @template_sale_id := 1;
-- 
-- START TRANSACTION;
-- 
-- -- ==========================================
-- -- Get item info + compute subtotal/tax/total
-- -- ==========================================
-- SELECT `id`, `name`, `price1`
-- INTO   @item_id, @item_name, @unit_price
-- FROM tbl_items
-- WHERE `code` = @item_code
-- LIMIT 1;
-- 
-- -- Tax in your samples looks like 10%
-- SET @tax_rate := 10;
-- SET @tax_amount := ROUND(@unit_price * @tax_rate / 100, 0);
-- 
-- SET @subtotal := @unit_price;
-- SET @total := @subtotal + @tax_amount;
-- 
-- -- ==================================
-- -- 1) Create a new sale by cloning one
-- -- ==================================
-- INSERT INTO tbl_sales
-- (
--   `address`, `closed`, `closedAt`, `closedTime`, `compoundTax`, `created`, `createdAt`,
--   `customerName`, `date`, `delivered`, `discountAmount`, `gratuity`, `mode`, `notes`,
--   `pax`, `phone`, `postcode`, `preparedFor`, `printCount`, `rounding`, `roundingAmount`,
--   `serviceCharge`, `serviceChargeAmount`, `serviceChargeBeforeDiscount`, `serviceChargeName`,
--   `state`, `status`, `subtotal`, `suburb`, `tabCardNo`, `tableName`,
--   `tax1`, `tax1Amount`, `tax1Name`, `tax2`, `tax2Amount`, `tax2Name`, `tax3`, `tax3Amount`, `tax3Name`,
--   `taxBeforeDiscount`, `taxOnServiceCharge`, `tip`, `total`, `type`, `version`,
--   `server_id`, `invoice_id`, `createdBy_id`, `closedBy_id`, `customer_id`, `driver_id`,
--   `cashierCode`, `cashierName`, `customerCode`, `driverCode`, `driverName`,
--   `invoiceNo`, `outlet`, `serverCode`, `serverName`, `submit`, `deliveryDate`, `timer`,
--   `voidCheck`, `taxNo`, `shiftName`, `shiftNo`, `voidReason`, `deliveryCharge`,
--   `accountReceivable`, `memberName`, `arDue`, `dateIndex`, `nonTaxItem`, `roomNo`,
--   `trobex`, `trobexStatus`, `appsindoId`, `cardNo`, `extraCharge`, `stampsEarned`,
--   `stampsEmail`, `stampsId`, `stampsRemaining`, `cloudCustomer`, `cloudId`,
--   `customApiId`, `qr`, `referenceCode`, `stampsBalance`, `weeloy`, `internal`
-- )
-- SELECT
--   `address`,
--   1,                 -- closed
--   `closedAt`,
--   NOW(),             -- closedTime (make it "now")
--   `compoundTax`,
--   NOW(),             -- created (now)
--   `createdAt`,
--   `customerName`,
--   NOW(),             -- date (now)
--   `delivered`,
--   0,                 -- discountAmount
--   0,                 -- gratuity
--   'DINE IN',          -- mode
--   CONCAT('SIMULATE ', @item_code),
--   `pax`,
--   `phone`,
--   `postcode`,
--   `preparedFor`,
--   1,                 -- printCount
--   `rounding`,
--   0,                 -- roundingAmount
--   0,                 -- serviceCharge
--   0,                 -- serviceChargeAmount
--   0,                 -- serviceChargeBeforeDiscount
--   `serviceChargeName`,
--   `state`,
--   0,                 -- status
--   @subtotal,         -- subtotal
--   `suburb`,
--   `tabCardNo`,
--   `tableName`,
--   @tax_rate,         -- tax1
--   @tax_amount,       -- tax1Amount
--   `tax1Name`,
--   0, 0, `tax2Name`,  -- tax2/tax2Amount
--   0, 0, `tax3Name`,  -- tax3/tax3Amount
--   `taxBeforeDiscount`,
--   `taxOnServiceCharge`,
--   0,                 -- tip
--   @total,            -- total
--   `type`,
--   `version`,
--   `server_id`, `invoice_id`, `createdBy_id`, `closedBy_id`, `customer_id`, `driver_id`,
--   `cashierCode`, `cashierName`, `customerCode`, `driverCode`, `driverName`,
--   `invoiceNo`, `outlet`, `serverCode`, `serverName`, `submit`, `deliveryDate`, `timer`,
--   `voidCheck`, `taxNo`, `shiftName`, `shiftNo`, `voidReason`, `deliveryCharge`,
--   `accountReceivable`, `memberName`, `arDue`, `dateIndex`, `nonTaxItem`, `roomNo`,
--   `trobex`, `trobexStatus`, `appsindoId`, `cardNo`, `extraCharge`, `stampsEarned`,
--   `stampsEmail`, `stampsId`, `stampsRemaining`, `cloudCustomer`, `cloudId`,
--   `customApiId`, `qr`, `referenceCode`, `stampsBalance`, `weeloy`, `internal`
-- FROM tbl_sales
-- WHERE `id` = @template_sale_id;
-- 
-- SET @new_sale_id := LAST_INSERT_ID();
-- 
-- -- ==================================================
-- -- 2) Insert ONE item sales_line by cloning an existing
-- -- ==================================================
-- INSERT INTO tbl_sales_lines
-- (
--   `amount`, `cardExpired`, `cardName`, `cardNo`, `changeAmount`, `created`, `description`,
--   `discountAmount`, `discountValue`, `memberDiscount`, `mode`, `quantity`, `remark`, `seat`,
--   `serviceChargeAmount`, `serviceChargeRate`, `tax1Amount`, `tax2Amount`, `tax3Amount`, `type`,
--   `unitCost`, `unitPrice`, `voidQuantity`, `voidReason`, `parent_id`, `employee_id`, `item_id`,
--   `discountLine_id`, `paymentMethod_id`, `discount_id`, `sales_id`, `idx`, `createdAt`, `category`,
--   `department`, `discountCode`, `discountName`, `employeeCode`, `employeeName`, `itemCode`, `itemName`,
--   `paymentMethodCode`, `paymentMethodName`, `rentalDuration`, `stopRental`, `arPaymentDate`,
--   `arPaymentMethod`, `arRemark`, `arStation`, `arEmployee_id`, `comboDetail`, `minimumCharge`,
--   `trobexStatus`, `redemptionId`, `changePrice`, `interchange`, `tax1`, `tax2`, `vatablePrice`,
--   `voidEmployee`, `voidPayment`, `voidTime`, `interchangeParent_id`
-- )
-- SELECT
--   0, `cardExpired`, `cardName`, `cardNo`, 0, NOW(),
--   @item_name,             -- description
--   0, 0, `memberDiscount`,
--   'DINE IN',
--   1,                      -- quantity
--   `remark`, `seat`,
--   0, 0,
--   @tax_amount,            -- tax1Amount
--   0, 0,
--   1,                      -- type = item line
--   0,
--   @unit_price,            -- unitPrice
--   0, '',
--   `parent_id`, `employee_id`,
--   @item_id,               -- item_id
--   `discountLine_id`, NULL, `discount_id`,
--   @new_sale_id,           -- sales_id
--   0,                      -- idx
--   `createdAt`,
--   `category`, `department`,
--   `discountCode`, `discountName`, `employeeCode`, `employeeName`,
--   @item_code,             -- itemCode
--   @item_name,             -- itemName
--   `paymentMethodCode`, `paymentMethodName`,
--   0, `stopRental`, `arPaymentDate`, `arPaymentMethod`, `arRemark`, `arStation`, `arEmployee_id`,
--   `comboDetail`, `minimumCharge`,
--   `trobexStatus`, `redemptionId`, `changePrice`, `interchange`,
--   @tax_rate, 0,
--   @unit_price,            -- vatablePrice
--   `voidEmployee`, `voidPayment`, `voidTime`, `interchangeParent_id`
-- FROM tbl_sales_lines
-- WHERE `type` = 1
-- LIMIT 1;
-- 
-- -- ======================================================
-- -- 3) Insert CASH payment line by cloning an existing CASH
-- -- ======================================================
-- INSERT INTO tbl_sales_lines
-- (
--   `amount`, `cardExpired`, `cardName`, `cardNo`, `changeAmount`, `created`, `description`,
--   `discountAmount`, `discountValue`, `memberDiscount`, `mode`, `quantity`, `remark`, `seat`,
--   `serviceChargeAmount`, `serviceChargeRate`, `tax1Amount`, `tax2Amount`, `tax3Amount`, `type`,
--   `unitCost`, `unitPrice`, `voidQuantity`, `voidReason`, `parent_id`, `employee_id`, `item_id`,
--   `discountLine_id`, `paymentMethod_id`, `discount_id`, `sales_id`, `idx`, `createdAt`, `category`,
--   `department`, `discountCode`, `discountName`, `employeeCode`, `employeeName`, `itemCode`, `itemName`,
--   `paymentMethodCode`, `paymentMethodName`, `rentalDuration`, `stopRental`, `arPaymentDate`,
--   `arPaymentMethod`, `arRemark`, `arStation`, `arEmployee_id`, `comboDetail`, `minimumCharge`,
--   `trobexStatus`, `redemptionId`, `changePrice`, `interchange`, `tax1`, `tax2`, `vatablePrice`,
--   `voidEmployee`, `voidPayment`, `voidTime`, `interchangeParent_id`
-- )
-- SELECT
--   @total,                 -- amount = sale total
--   `cardExpired`, `cardName`, `cardNo`,
--   0, NOW(),
--   'CASH',                 -- description
--   0, 0, `memberDiscount`,
--   '',
--   1, '',
--   `seat`,
--   0, 0,
--   0, 0, 0,
--   3,                     -- type = payment line
--   0, 0,
--   0, '',
--   `parent_id`, `employee_id`, `item_id`,
--   `discountLine_id`,
--   `paymentMethod_id`,     -- keep same payment method id from template CASH line
--   `discount_id`,
--   @new_sale_id,
--   1,                      -- idx
--   `createdAt`,
--   `category`, `department`,
--   `discountCode`, `discountName`, `employeeCode`, `employeeName`,
--   `itemCode`, `itemName`,
--   `paymentMethodCode`, `paymentMethodName`,
--   0, `stopRental`, `arPaymentDate`, `arPaymentMethod`, `arRemark`, `arStation`, `arEmployee_id`,
--   `comboDetail`, `minimumCharge`,
--   `trobexStatus`, `redemptionId`, `changePrice`, `interchange`,
--   0, 0, 0,
--   `voidEmployee`, `voidPayment`, `voidTime`, `interchangeParent_id`
-- FROM tbl_sales_lines
-- WHERE `type` = 3 AND `description` = 'CASH'
-- LIMIT 1;
-- 
-- COMMIT;
-- 
-- -- Review the simulated transaction
-- SELECT * FROM tbl_sales WHERE id = @new_sale_id;
-- SELECT * FROM tbl_sales_lines WHERE sales_id = @new_sale_id ORDER BY id;
-- 
-- 


-- INSERT INTO tbl_sales
-- (
--     `address`, `closed`, `closedAt`, `closedTime`, `compoundTax`,
--     `created`, `createdAt`, `customerName`, `date`, `delivered`,
--     `discountAmount`, `gratuity`, `mode`, `notes`, `pax`,
--     `phone`, `postcode`, `preparedFor`, `printCount`, `rounding`,
--     `roundingAmount`, `serviceCharge`, `serviceChargeAmount`,
--     `serviceChargeBeforeDiscount`, `serviceChargeName`, `state`,
--     `status`, `subtotal`, `suburb`, `tabCardNo`, `tableName`,
--     `tax1`, `tax1Amount`, `tax1Name`, `tax2`, `tax2Amount`, `tax2Name`,
--     `tax3`, `tax3Amount`, `tax3Name`, `taxBeforeDiscount`,
--     `taxOnServiceCharge`, `tip`, `total`, `type`, `version`,
--     `server_id`, `invoice_id`, `createdBy_id`, `closedBy_id`,
--     `customer_id`, `driver_id`, `cashierCode`, `cashierName`,
--     `customerCode`, `driverCode`, `driverName`, `invoiceNo`,
--     `outlet`, `serverCode`, `serverName`, `submit`, `deliveryDate`,
--     `timer`, `voidCheck`, `taxNo`, `shiftName`, `shiftNo`,
--     `voidReason`, `deliveryCharge`, `accountReceivable`,
--     `memberName`, `arDue`, `dateIndex`, `nonTaxItem`, `roomNo`,
--     `trobex`, `trobexStatus`, `appsindoId`, `cardNo`, `extraCharge`,
--     `stampsEarned`, `stampsEmail`, `stampsId`, `stampsRemaining`,
--     `cloudCustomer`, `cloudId`, `customApiId`, `qr`,
--     `referenceCode`, `stampsBalance`, `weeloy`, `internal`
-- )
-- VALUES
-- (
--     '', 1, 'cashier', NOW(), '\0',
--     NOW(), 'cashier', '', NOW(), '\0',
--     0, 0, 'DINE IN', 'SIMULATION PG0001+PG0002', 2,
--     '', NULL, NULL, 1, 100,
--     0, 0, 0,
--     0, 'Service charge', NULL,
--     0, 150000, NULL, '1768485808000', '1',
--     10, 15000, 'PB1', 0, 0, 'Tax2',
--     0, 0, 'Tax3', '\0',
--     '\0', 0, 165000, 'DINE IN', 1,
--     1, 1, 1, 1,
--     NULL, NULL, 'cashier', 'cashier',
--     '', '', '', '',
--     '', '', '', '\0', NULL,
--     NULL, '\0', NULL, 'Night', 2,
--     NULL, 0, '\0',
--     '', 0, '202601', '\0', '',
--     NULL, NULL, NULL, '', 0,
--     0, '', NULL, NULL,
--     '', NULL, NULL, '', '',
--     NULL, NULL, '\0'
-- );
-- 
SET @sale_id := 6;
-- 
INSERT INTO tbl_sales_lines
(
 amount, cardExpired, cardName, cardNo, changeAmount,
 created, description, discountAmount, discountValue,
 memberDiscount, MODE, quantity, remark, seat,
 serviceChargeAmount, serviceChargeRate,
 tax1Amount, tax2Amount, tax3Amount,
 TYPE, unitCost, unitPrice,
 voidQuantity, voidReason,
 parent_id, employee_id, item_id,
 discountLine_id, paymentMethod_id, discount_id,
 sales_id, idx, createdAt, category, department,
 discountCode, discountName, employeeCode, employeeName,
 itemCode, itemName, paymentMethodCode, paymentMethodName,
 rentalDuration, stopRental, arPaymentDate, arPaymentMethod,
 arRemark, arStation, arEmployee_id, comboDetail,
 minimumCharge, trobexStatus, redemptionId, changePrice,
 interchange, tax1, tax2, vatablePrice,
 voidEmployee, voidPayment, voidTime, interchangeParent_id
)
VALUES
(
 0,'','','',0,
 NOW(),'Playground 1 Jam',0,0,
 '\0','DINE IN',1,'',NULL,
 0,0,
 5000,0,0,
 1,0,50000,
 0,'',
 NULL,1,1,
 NULL,NULL,NULL,
 @sale_id,0,'cashier','', '',
 '', '', '', '',
 'PG0001','Playground 1 Jam','', '',
 0,0,NULL,'',
 '', '', NULL, '\0',
 0,'\0',NULL,NULL,
 '\0',10,0,50000,
 '\0','\0',NULL,NULL
);

INSERT INTO tbl_sales_lines
(
 amount, cardExpired, cardName, cardNo, changeAmount,
 created, description, discountAmount, discountValue,
 memberDiscount, MODE, quantity, remark, seat,
 serviceChargeAmount, serviceChargeRate,
 tax1Amount, tax2Amount, tax3Amount,
 TYPE, unitCost, unitPrice,
 voidQuantity, voidReason,
 parent_id, employee_id, item_id,
 discountLine_id, paymentMethod_id, discount_id,
 sales_id, idx, createdAt, category, department,
 discountCode, discountName, employeeCode, employeeName,
 itemCode, itemName, paymentMethodCode, paymentMethodName,
 rentalDuration, stopRental, arPaymentDate, arPaymentMethod,
 arRemark, arStation, arEmployee_id, comboDetail,
 minimumCharge, trobexStatus, redemptionId, changePrice,
 interchange, tax1, tax2, vatablePrice,
 voidEmployee, voidPayment, voidTime, interchangeParent_id
)
VALUES
(
 0,'','','',0,
 NOW(),'Playground 2 Jam',0,0,
 '\0','DINE IN',1,'',NULL,
 0,0,
 10000,0,0,
 1,0,100000,
 0,'',
 NULL,1,2,
 NULL,NULL,NULL,
 @sale_id,1,'cashier','', '',
 '', '', '', '',
 'PG0002','Playground 2 Jam','', '',
 0,0,NULL,'',
 '', '', NULL, '\0',
 0,'\0',NULL,NULL,
 '\0',10,0,100000,
 '\0','\0',NULL,NULL
);

INSERT INTO tbl_sales_lines
(
 amount, cardExpired, cardName, cardNo, changeAmount,
 created, description, discountAmount, discountValue,
 memberDiscount, MODE, quantity, remark, seat,
 serviceChargeAmount, serviceChargeRate,
 tax1Amount, tax2Amount, tax3Amount,
 TYPE, unitCost, unitPrice,
 voidQuantity, voidReason,
 parent_id, employee_id, item_id,
 discountLine_id, paymentMethod_id, discount_id,
 sales_id, idx, createdAt, category, department,
 discountCode, discountName, employeeCode, employeeName,
 itemCode, itemName, paymentMethodCode, paymentMethodName,
 rentalDuration, stopRental, arPaymentDate, arPaymentMethod,
 arRemark, arStation, arEmployee_id, comboDetail,
 minimumCharge, trobexStatus, redemptionId, changePrice,
 interchange, tax1, tax2, vatablePrice,
 voidEmployee, voidPayment, voidTime, interchangeParent_id
)
VALUES
(
 165000,'','','',0,
 NOW(),'CASH',0,0,
 '\0','',1,'',NULL,
 0,0,
 0,0,0,
 3,0,0,
 0,'',
 NULL,1,NULL,
 NULL,1,NULL,
 @sale_id,99,'cashier','', '',
 '', '', '', '',
 '','', 'CASH','CASH',
 0,0,NULL,'',
 '', '', NULL, '\0',
 0,'\0',NULL,NULL,
 '\0',0,0,0,
 '\0','\0',NULL,NULL
);


SELECT id, description, unitPrice, tax1Amount, TYPE
FROM tbl_sales_lines
WHERE sales_id = @sale_id
ORDER BY idx;

SELECT id, subtotal, tax1Amount, total
FROM tbl_sales
WHERE id = @sale_id;
