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
    notes
)
VALUES
(
    NOW(),
    'cashier',
    NOW(),
    1,
    'DINE IN',
    60000,
    0,
    0,
    60000,
    'cashier',
    'cashier',
    'Night',
    1,
    DATE_FORMAT(NOW(), '%Y%m'),
    1,
    'DINE IN',
    0,
    ''
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
    vatablePrice,
    Remark
)
SELECT
    NOW(),
    NAME,
    'DINE IN',
    3,
    1,              -- ITEM
    price1,
    0,
    @sale_id,
    0,
    id,
    CODE,
    NAME,
    price1,
    'F-TRT.JOYLAND-26-000009'
FROM tbl_items
WHERE CODE = 'PG0004';

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
    60000,
    NOW(),
    'CASH',
    3,          -- PAYMENT
    1,
    @sale_id,
    99,
    'CASH',
    'CASH'
);

SELECT id, description, unitPrice, amount, TYPE
FROM tbl_sales_lines
WHERE sales_id = @sale_id;

SELECT *
FROM tbl_sales
WHERE id = @sale_id;

UPDATE tbl_sales_lines SET remark = 'F-TRT.JOYLAND-26-000008' WHERE sales_id = @sale_id;


