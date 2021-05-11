import json
from os.path import dirname, join
from time import sleep

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

AUTH_HEADERS = {
    'x-rapidapi-key': "4e18bf3b86mshdd530c160a389acp1dec3ejsn2a0de404f414",
    'x-rapidapi-host': "asos2.p.rapidapi.com"
}


def main():
    url = "https://asos2.p.rapidapi.com/products/v2/list"

    categories_filename = join(dirname(__file__), "categories.json")
    with open(categories_filename) as f:
        data = json.load(f)

    for x in data:

        # logging
        print(f"Processing category ID {x}")

        # get the products in this category
        querystring = {"offset": "0", "categoryId": x, "limit": "5", "store": "US", "country": "US",
                       "currency": "USD", "sort": "", "lang": "en-US", "sizeSchema": "US"}  # shoes, boots and sneakers
        response = requests.request("GET", url, headers=AUTH_HEADERS, params=querystring)

        # parse respons json, so we can add additional custom fields (colours),
        # that are extracted from the product details.
        clothings = response.json()
        products = clothings["products"]

        for product in products:

            # logging
            product_name = product["name"]
            print(f" - Processing product: {product_name}")

            # get product detail
            product_id = product["id"]
            product_details = get_product_detail(product_id)

            # get the colours
            variants = product_details["variants"]
            colours = {variant["colour"] for variant in variants}

            # put into original product
            product["customColours"] = list(colours)

            # wait for 3 seconds to avoid overloading the API
            sleep(3.0)

        # turn modified response back to json
        with open(x + '.json', 'w') as f:
            json.dump(clothings, f)


def get_product_detail(product_id):
    url = "https://asos2.p.rapidapi.com/products/v3/detail"
    params = {"id": product_id}
    response = requests.get(url, params=params, headers=AUTH_HEADERS)
    return response.json()


if __name__ == '__main__':
    main()
