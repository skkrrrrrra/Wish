using FluentMigrator;
using Wish.Persistence.Common;

namespace Wish.Persistence.Migrations;

[Migration(10, "Add categories to categories table")]
public class AddProducts : SqlMigration
{
	protected override string GetUpSql(IServiceProvider services) => @"

	--EARRINGS--


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотые серьги с фианитами и топазами',
	'Серьги с 2 топазами, 0.92 карат, тип огранки В; фианит;Розовое золото 585 пробы.',
	'2',
	'https://g3.sunlight.net/media/i/400/91/products/a7fd87cddc364a474fb92346ffe930e89b5ea461.jpg',
	'1',
	'1.84',
	'10',
	'10990');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотые серьги с бриллиантами',
	'Серьги с 10 бриллиантами, огранка круг 17 граней, 0.022 карат, цвет 2, чистота 2, тип огранки Б;Розовое золото 585 пробы.',
	'2',
	'https://g5.sunlight.net/media/products/e19e76d36642a865c28d0597a1af8028fc420708.jpg',
	'1',
	'2.00',
	'2',
	'12490');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотые серьги с фианитами',
	'Серьги, вставка:  фианит б/ц;Розовое золото 585 пробы.',
	'2',
	'https://g4.sunlight.net/media/products/39112dc2e44062c850c0b0c64910d2aa6259545d.jpg',
	'1',
	'1.42',
	'30',
	'10490');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотые серьги с фианитами и топазами',
	'Серьги с 2 топазами свисс, 1.171 карат, тип огранки В; фианит бесцветный;Розовое золото 585 пробы.',
	'2',
	'https://g6.sunlight.net/media/products/bd6e2a96ba89a42c2614bd343fa48fe82123c41c.jpg',
	'1',
	'1.55',
	'1',
	'30000');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотые серьги с топазами и фианитами',
	'Серьги из красного золота 585 пробы с 2 топазами sky и 2 фианитами. Английский замок — один из самых надежных.',
	'2',
	'https://g4.sunlight.net/media/products/caf78f73e41b605a688799ccadee852d5c7c1b82.jpg',
	'1',
	'1.9',
	'5',
	'15100');





	--RINGS--

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое кольцо с топазом и фианитами',
	'Кольцо из розового золота 585 пробы с 1 топазом sky и фианитами. Родирование придает изделию дополнительный блеск.',
	'1',
	'https://g9.sunlight.net/media/products/a2d216418162ec4b369836607674acdb32a99a34.jpg',
	'1',
	'0.9',
	'7',
	'6490');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое кольцо с фианитами',
	'Кольцо, вставка:  фианит бесцветный; фианит бесцветный;Желтое золото 585 пробы.',
	'1',
	'https://g2.sunlight.net/media/products/fa70bbf1-b74e-11ed-847f-0050568ccb93.jpg',
	'1',
	'1.91',
	'3',
	'11490');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое кольцо с фианитами',
	'Кольцо, вставка:  фианит бесцветный;Розовое золото 585 пробы.',
	'1',
	'https://g7.sunlight.net/media/products/00aef395867980ee07088361af604cde594cc24c.jpg',
	'1',
	'1.99',
	'3',
	'11490');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое кольцо с бриллиантами',
	'Кольцо «Бриллианты Якутии» с 1 бриллиантом, огранка круг 57 граней, 0.05 карат, цвет 3, чистота 6, тип огранки А, 6 бриллиантами, огранка круг 57 граней, 0.11 карат, цвет 3, чистота 6, тип огранки А, 20 бриллиантами, огранка круг 17 граней, 0.06 карат, цвет 2, чистота 2, тип огранки Б;Розовое золото 585 пробы',
	'1',
	'https://g5.sunlight.net/media/i/380/85/products/acf14fbe0e770ca046e4be223c95e0848d42991c.jpg',
	'1',
	'1.70',
	'1',
	'39990');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое кольцо с фианитами',
	'Классические ювелирные украшения. Ювелирные украшения в классическом стиле: вне моды и времени. Отличительные признаки классики: спокойные плавные линии; гармоничные пропорции, симметричность, стандартные геометрические формы. Вы не прогадаете ни с собственным образом, ни с подарком!',
	'1',
	'https://g4.sunlight.net/media/products/2a35fc11-f397-11eb-8230-005056b30bd2.jpg',
	'1',
	'2.07',
	'15',
	'13490');




	--Armlets--


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотой браслет',
	'Браслет ручной работы.Розовое золото 585 пробы.',
	'4',
	'https://g2.sunlight.net/media/products/01010ab69387693aaab7a97989beb8e4c10e5585.jpg',
	'1',
	'11.28',
	'10',
	'43879');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотой браслет',
	'Браслет.Желтое золото 585 пробы.',
	'4',
	'https://g2.sunlight.net/media/products/d2a5a5d621722974da9f4c1256778682794872ef.jpg',
	'1',
	'10.72',
	'4',
	'80990');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотой браслет',
	'Браслет.Розовое золото 585 пробы.БРАСЛЕТ ОБЛЕГЧЕННЫЙ. ТРЕБУЕТ БЕРЕЖНОГО ОБРАЩЕНИЯ. Украшение произведено по итальянской технологии изготовления облегченных (пустотелых) ювелирных изделий. Оно требует аккуратного и бережного обращения. ',
	'4',
	'https://g6.sunlight.net/media/products/9d9c2d4345a1d024e62319b955e4bcc177221104.jpg',
	'1',
	'6.72',
	'12',
	'48720');
	
	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотой браслет с бриллиантами',
	'Браслет с 3 бриллиантами, огранка круг 57 граней, 0.22 карат, цвет 4, чистота 6, тип огранки А, 36 бриллиантами, огранка круг 17 граней, 0.31 карат, цвет 2, чистота 3, тип огранки Б;',
	'4',
	'https://g3.sunlight.net/media/products/0a248ed2313e577b562bd026267179dcd299bdaa.jpg',
	'1',
	'8.40',
	'2',
	'166633');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотой браслет с фианитами',
	'Браслет, вставка:  фианит бесцветный;Розовое золото 585 пробы.',
	'4',
	'https://g1.sunlight.net/media/products/ac36d72f-bb0b-11ec-8332-005056b30bd2.jpg',
	'1',
	'3.85',
	'2',
	'26990');

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотой браслет с топазами и фианитами',
	'Браслет из розового золота 585 пробы с 14 топазами синими и фианитами. Родирование придает изделию дополнительный блеск.',
	'4',
	'https://g2.sunlight.net/media/products/5a22567c-d3f6-11eb-8207-005056b30bd2.jpg',
	'1',
	'3.81',
	'3',
	'26990');





	--Necklaces--
	

	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое ожерелье с топазами и фианитами',
	'Ожерелье из розового золота 585 пробы с 13 топазами голубыми и фианитами. Родирование придает изделию дополнительный блеск.',
	'3',
	'https://g1.sunlight.net/media/products/89b016e5b9b4944ac36fff67b6e20dc212482ed2.jpg',
	'1',
	'4.35',
	'5',
	'31990');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое ожерелье с топазами и бриллиантами',
	'Ожерелье из белого золота 585 пробы с 8 топазами и 8 бриллиантами. Изделие имеет элегантный дизайн и высокое качество исполнения.',
	'3',
	'https://g1.sunlight.net/media/products/84813b87-9ce7-11eb-81bf-005056b30bd2.jpg',
	'1',
	'3.02',
	'4',
	'29960');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое ожерелье с топазами и хризолитами',
	'Ожерелье из желтого золота 585 пробы с 10 топазами голубыми и 10 хризолитами. Изделие имеет яркий и нарядный вид.',
	'3',
	'https://g5.sunlight.net/media/products/460e1cec-c8eb-11eb-81f8-005056b30bd2.jpg',
	'1',
	'5.67',
	'3',
	'34990');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое ожерелье с топазами и фианитами',
	'Ожерелье из розового золота 585 пробы с 14 топазами синими и фианитами. Изделие отличается оригинальным дизайном и высоким качеством от бренда ALORIS.',
	'3',
	'https://g1.sunlight.net/media/products/89b016e5b9b4944ac36fff67b6e20dc212482ed2.jpg',
	'1',
	'6.22',
	'2',
	'52990');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
	('Золотое ожерелье с топазами',
	'Ожерелье из белого золота 585 пробы с 10 топазами голубыми. Изделие принадлежит коллекции SOKOLOV Infinity и символизирует бесконечность любви и красоты.',
	'3',
	'https://diamant-online.ru/uploads/shop/770366.jpg',
	'1',
	'4.81',
	'6',
	'21990');


	INSERT INTO products
	(title, description, category_id, picture_link, material, weight, count, price)
	VALUES
    ('Золотое ожерелье с топазами и фианитами',
    'Ожерелье из розового золота 585 пробы с 14 топазами скай и фианитами. Изделие отличается нежным цветом и изящной формой от бренда SERGEY GRIBNYAKOV.',
    '3',
    'https://svita.shop/components/com_jshopping/files/img_products/full_b6b1425cc84aa0faf22e1dd24e99ed28.webp',
    '1',
    '3.26',
    '4',
    '26990');


	
";

    protected override string GetDownSql(IServiceProvider services) => @"
	DELETE FROM products;
";
}
