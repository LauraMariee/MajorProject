import requests
import json

url = "https://asos2.p.rapidapi.com/products/v2/list"

querystring = {"offset":"0","categoryId":"4209","limit":"48","store":"US","country":"US","currency":"USD","sort":"","lang":"en-US","sizeSchema":"US"}  # shoes, boots and sneakers


# womens catagories
# 11321 - hoodies and sweatshirts
# 4169 - Tops
# 3630 - Jeans
# 8799 - Dress's

# men catagories
# 7616 - Tshirts and vests
# 4208 - Jeans
# 5668 - Hoodies
# 18797 - loungewear

headers = {
    'x-rapidapi-key': "4e18bf3b86mshdd530c160a389acp1dec3ejsn2a0de404f414",
    'x-rapidapi-host': "asos2.p.rapidapi.com"
    }

response = requests.request("GET", url, headers=headers, params=querystring)

writeFile = open('testFile.json', 'w')
writeFile.write(response.text)
writeFile.close()

print(response.text)
