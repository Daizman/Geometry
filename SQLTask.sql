--Products(id, name)
--Categories(id, name)
--ProductCategories(productId, categoryId)  many to many
select pr.Name as 'Имя продукта', cat.Name as 'Имя категории'
from Products pr
left join ProductCategories prCat on pr.Id = prCat.ProductId
left join Categories cat on prCat.CategoryId = cat.Id;