SET @qty_pg1 := 2;   -- change to 3 if needed
SET @qty_pg2 := 3;   -- change to 2 or 3 as needed


SELECT price1 INTO @p1 FROM tbl_items WHERE CODE='PG0001';
SELECT price1 INTO @p2 FROM tbl_items WHERE CODE='PG0002';

SET @subtotal := (@p1 * @qty_pg1) + (@p2 * @qty_pg2);
SET @total := @subtotal;   -- no tax/service for this simple sim

INSERT INTO tbl_sales
(
    created,
    createdAt,
    DATE,
    closed,
    MODE,
    subtotal,
    tax1,
    tax1Amount,
    total,
    cashierCode,
    cashierName,
    shiftName,
    shiftNo,
    dateIndex,
    VERSION,
    TYPE,
    STATUS,
    pax,
    notes
)
VALUES
(
    NOW(),
    'cashier',
    NOW(),
    1,
    'DINE IN',
    @subtotal,
    0,
    0,
    @total,
    'cashier',
    'cashier',
    'Night',
    1,
    DATE_FORMAT(NOW(), '%Y%m'),
    1,
    'DINE IN',
    0,
    @qty_pg1 + @qty_pg2,
    'SIM COMBO PG0001 + PG0002'
);

SET @sale_id := LAST_INSERT_ID();


INSERT INTO tbl_sales_lines
(
    created,
    description,
    MODE,
    quantity,
    TYPE,
    unitPrice,
    tax1Amount,
    sales_id,
    idx,
    item_id,
    itemCode,
    itemName,
    vatablePrice
)
SELECT
    NOW(),
    NAME,
    'DINE IN',
    @qty_pg1,
    1,
    price1,
    0,
    @sale_id,
    0,
    id,
    CODE,
    NAME,
    price1
FROM tbl_items
WHERE CODE='PG0001';


INSERT INTO tbl_sales_lines
(
    created,
    description,
    MODE,
    quantity,
    TYPE,
    unitPrice,
    tax1Amount,
    sales_id,
    idx,
    item_id,
    itemCode,
    itemName,
    vatablePrice
)
SELECT
    NOW(),
    NAME,
    'DINE IN',
    @qty_pg2,
    1,
    price1,
    0,
    @sale_id,
    1,
    id,
    CODE,
    NAME,
    price1
FROM tbl_items
WHERE CODE='PG0002';


INSERT INTO tbl_sales_lines
(
    amount,
    created,
    description,
    TYPE,
    quantity,
    sales_id,
    idx,
    paymentMethodCode,
    paymentMethodName
)
VALUES
(
    @total,
    NOW(),
    'CASH',
    3,
    1,
    @sale_id,
    99,
    'CASH',
    'CASH'
);


SELECT description, quantity, unitPrice, TYPE
FROM tbl_sales_lines
WHERE sales_id=@sale_id
ORDER BY idx;

SELECT subtotal, total, pax, notes
FROM tbl_sales
WHERE id=@sale_id;


