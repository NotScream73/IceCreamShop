using IceCreamShopBusinessLogic.OfficePackage.HelperEnums;
using IceCreamShopBusinessLogic.OfficePackage.HelperModels;

namespace IceCreamShopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var iceCream in info.IceCreams)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (iceCream.IceCreamName + " ", new WordTextProperties { Bold = true, Size = "24" }),
                                                                     (iceCream.Price.ToString(), new WordTextProperties { Size = "24" }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        public void CreateTable(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            List<List<(string, WordTextProperties)>> rowList = new()
            {
                new()
                {
                    new("Название", new WordTextProperties { Bold = true, Size = "24" } ),
                    new("Адрес", new WordTextProperties { Bold = true, Size = "24" } ),
                    new("Дата открытия", new WordTextProperties { Bold = true, Size = "24" } )
                }
            };

            foreach (var shop in info.Shops)
            {
                List<(string, WordTextProperties)> cellList = new()
                {
                    new(shop.ShopName, new WordTextProperties { Size = "24" }),
                    new(shop.Address, new WordTextProperties { Size = "24" }),
                    new(shop.DateOpen.ToShortDateString(), new WordTextProperties { Size = "24"})
                };
                rowList.Add(cellList);
            }

            CreateTable(new WordParagraph
            {
                RowTexts = rowList,
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            SaveWord(info);
        }

        /// <summary>
		/// Создание doc-файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void CreateWord(WordInfo info);

        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);
        
        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateTable(WordParagraph paragraph);

        /// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void SaveWord(WordInfo info);
    }
}
