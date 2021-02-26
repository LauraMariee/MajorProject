import requests

# womens categories
# 11321 - hoodies and sweatshirts
# 4169 - Tops
# 3630 - Jeans
# 8799 - Dress's

# men categories
# 7616 - Tshirts and vests
# 4208 - Jeans
# 5668 - Hoodies
# 18797 - loungewear


url = "https://asos2.p.rapidapi.com/products/v2/list"

clothingCategory = ["11321", "4169", "3630", "8799", "7616", "4208", "5668", "18797"]
for x in clothingCategory:
    querystring = {"offset": "0", "categoryId": x, "limit": "48", "store": "US", "country": "US",
                   "currency": "USD", "sort": "", "lang": "en-US", "sizeSchema": "US"}  # shoes, boots and sneakers

    headers = {
        'x-rapidapi-key': "4e18bf3b86mshdd530c160a389acp1dec3ejsn2a0de404f414",
        'x-rapidapi-host': "asos2.p.rapidapi.com"
    }

    response = requests.request("GET", url, headers=headers, params=querystring)

    writeFile = open( x + '.json', 'w')
    writeFile.write(response.text)
    writeFile.close()

    print(response.text)
