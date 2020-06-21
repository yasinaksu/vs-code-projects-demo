using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            StudentProductBuilder studentBuilder = new StudentProductBuilder();
            TeacherProductBuilder teacherBuilder = new TeacherProductBuilder();
            Product product = new Product { Name = "Laptop", Price = 3000 };
            var saledProducForStudent = productDirector.GenerateProduct(studentBuilder, product);
            var saledProducForTeacher = productDirector.GenerateProduct(teacherBuilder, product);

            Console.WriteLine($"Ürün Adı : {product.Name} Fiyat : {product.Price} Öğrenci İndirimli Fiyatı : {saledProducForStudent.Price}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Ürün Adı : {product.Name} Fiyat : {product.Price} Öğretmen İndirimli Fiyatı : {saledProducForTeacher.Price}");
        }
    }

    class StudentProductBuilder : ProductBuilder
    {
        Product _product = new Product();
        public override Product ApplyDiscount(Product product)
        {
            _product.Name=product.Name;
            _product.Price=product.Price*0.80m;
            return _product;
        }
    }

    class TeacherProductBuilder : ProductBuilder
    {
        Product _product = new Product();
        public override Product ApplyDiscount(Product product)
        {
            _product.Name=product.Name;
            _product.Price=product.Price*0.90m;
            return _product;
        }
    }

    class ProductDirector
    {
        public Product GenerateProduct(ProductBuilder builder, Product product)
        {
            return builder.ApplyDiscount(product);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract Product ApplyDiscount(Product product);
    }
}
