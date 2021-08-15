using FA.JustBlog.Models.Common;
using FA.JustBlog.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Data
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<JustBlogContext>
    {
        protected override void Seed(JustBlogContext context)
        {
            InitializeIdentity(context);

            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Thai",
                    UrlSlug = "thai",
                    Description = "",
                    IsDeleted = false
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dessert",
                    UrlSlug = "dessert",
                    Description = "",
                    IsDeleted = false
                },
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vegan",
                    UrlSlug = "vegan",
                    Description = "",
                    IsDeleted = false
                }, 
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mexican",
                    UrlSlug = "mexican",
                    Description = "",
                    IsDeleted = false
                }, 
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Italian",
                    UrlSlug = "italian",
                    Description = "",
                    IsDeleted = false
                },
            };
            context.Categories.AddRange(categories);

            var post1 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Creamy Sausage-Stuffed Mushrooms",
                ShortDescription = "This is a twist on my ex-boyfriend's mother's recipe which I couldn't help but think I could make so much better, and I did. This is something I make for Thanksgiving and even the children who don't like mushrooms love it.",
                ImageUrl = "creamy-sausage.jpg",
                PostContent = "<p>Adriene&#39;s stuffed mushrooms are the kind of coveted hors d&#39;oeuvres that go all too fast at a party -- so it&#39;s a good thing this recipe makes enough for a big crowd. The splash of balsamic that cloaks the mushrooms prior to their first go-round in the oven infuses them with a touch of sweetness and acidity that acts as a wonderful counterpoint to the savory sausage-laced cream cheese stuffing. We chose an aged Asiago and, though it didn&#39;t melt as well as a fresh one would, we loved the earthy, piquant accent it added to these rich, addictive little &#39;shrooms. &mdash;The Editors</p><h1><strong>Ingredients</strong></h1><p>5 pints button mushrooms</p><p>4 Italian sausage links</p><p>8 ounces cream cheese, at room temperature</p><p>2 yellow onions, minced</p><p>5 garlic cloves, minced</p><p>5 ounces asiago cheese, shredded</p><p>7 tablespoons olive oil</p><p>3 tablespoons balsamic vinegar</p><p>salt and pepper</p><h1>Directions</h1><ol>	<li>Preheat your oven to 350&deg; F. Wipe mushrooms clean with a damp cloth and pull out the stems and discard. Toss the cleaned de-stemmed mushrooms with 5 tablespoons of olive oil, balsamic vinegar, salt, and pepper. Spread out on a sheet pan and bake for 30 minutes. Set aside and cool.</li>	<li>Slit the Italian sausage and remove casing. Crumble in a heated pan and saut&eacute; until golden brown. Break up into small pieces while it is cooking. Set aside and cool.</li>	<li>Add the remaining 2 tablespoons of olive oil in a saut&eacute; pan and add the onions. Cook until dark and caramelized, about 15 to 20 minutes. Then add in the garlic and cook for a minute.</li>	<li>Now add the cooked sausage, onions and garlic, cream cheese, salt and pepper, and 3 oounces of shredded Asiago cheese to a bowl and mix well with your hands. Break apart any large pieces of sausage.</li>	<li>Heat your oven to 375&deg;&nbsp;F. Line up your mushrooms in a greased baking dish with the core side facing up. Stuff each mushroom with a generous portion of the creamy sausage mixture. Top the mushrooms with the remaining Asiago cheese.</li>	<li>Bake your mushrooms for roughly 45 minutes or until the cheese on top is golden brown. (This dish can be made up to 3 days ahead of time and put in the cooler until you are ready to put it in the oven.)</li></ol>",
                UrlSlug = "creamy-sausage-stuffed-mushrooms",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Italian"),
                IsDeleted = false,
                ViewCount = 1000,
                RateCount = 800,
                TotalRate = 3500,
                ImageSlider = "creamy-sausage-s.jpg"
            };
            var post2 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Apple Chips ",
                ShortDescription = "I borrowed the technique for these from Rivka, whose Cocoa Pear Crisps, were an early recipe contest winner. You don't need to add anything to the apples, but I often sprinkle half of them with a little cinnamon to keep things lively.",
                ImageUrl = "apple-chips.jpg",
                PostContent = "<h1><strong>Ingredients</h1><p>2 medium, crisp apples (I like Jonagold), washed and dried</p><p>1/2 teaspoon ground cinnamon (optional)</p><h1><strong>Directions</strong></h1><ol>	<li>Heat the oven to 275&deg;F. Use an apple corer to core the apples.</li>	<li>Set a mandoline to the 1/4-inch setting and slice each apple into about 15 thin slices. Or, slice the apples as thinly as you can by hand. Arrange the apple slices on two cooling racks set on top of baking sheets. (You can also used a Silpat-lined baking sheet.)</li>	<li>Sprinkle the cinnamon over the apple slices if using. Bake the apple slices almost dry, about 1 hour, flipping them over and rotating the baking sheets halfway through to ensure even baking. Cool the apple chips on a rack and serve or store in an airtight container for up to 2 days.</li></ol>",
                UrlSlug = "apple-chips",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Vegan"),
                IsDeleted = false,
                ViewCount = 2500,
                RateCount = 800,
                TotalRate = 3400,
                ImageSlider = "apple-chips-s.jpg"
            };
            var post3 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Winter Fruit Salsa ",
                ShortDescription = "This combination of bright fruit makes a great appetizer for a wintertime gathering. Pomegranate arils add tang and texture while persimmon flesh adds sweetness and substance. Rich avocado partly melts into a creamy binder when stirred in.",
                ImageUrl = "winter-fruit-salsa.jpg",
                PostContent = "<p>The flavors are brought together with lime juice, shallot, serrano pepper, and a slightly unexpected herb and spice combination. Serve with pita chips or lavash, or consider using in place of a mango or pineapple salsa and serve it with pork chops or chicken.</p><h1><strong>Ingredients</strong></h1><p>1/4 cup freshly squeezed lime juice (2 large limes)</p><p>1/8 teaspoon salt</p><p>3 tablespoons minced shallot (2 medium-large cloves)</p><p>2 persimmons, peeled and diced</p><p>1 1/3 cups pomegranate arils (1 large pomegranate)</p><p>1 large Hass avocado, flesh diced</p><p>1 serrano chile, seeds and veins removed, flesh minced</p><p>2 tablespoons chiffonade mint</p><p>2 teaspoons minced sage</p><p>1/8 teaspoon cinnamon</p><h1><strong>Directions</strong></h1><ol>	<li>Combine lime juice, salt, and minced shallot in a medium non-reactive bowl while prepping the rest of the ingredients.</li>	<li>Dice the persimmon and avocado so the pieces are about the same size as a pomegranate aril. As ingredients are prepped, add them to the bowl, gently tossing to incorporate. When everything has been added, toss to blend.</li>	<li>Allow flavors to meld 20 to 60 minutes before serving. This holds up for several hours, so is best made the same day. It tastes fine later, but the avocado gets a little ugly.</li></ol>",
                UrlSlug = "winter-fruit-salsa",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Vegan"),
                IsDeleted = false,
                ViewCount = 6000,
                RateCount = 3000,
                TotalRate = 10000,
                ImageSlider = "winter-fruit-salsa-s.jpg"
            };

            var post4 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Chocolate Thai Green Curry Cake",
                ShortDescription = "So many flavors in Thai cooking straddle the line between sweet and savory - coconut, ginger, kaffir lime, lemongrass, even chile - so I didn't think twice about translating one of my favorite Thai dishes, green curry, into something sweet.",
                ImageUrl = "thai-green-curry-cake.jpg",
                PostContent = "<p>I came up with this recipe several years ago for a challenge to create a dessert with eggplant in it - the cake was really a sweet and chocolatey version of green curry with eggplant - and have since modified the recipe to omit the eggplant in the cake batter as well as the topping so as to simplify the recipe a bit.</p><p>The cake is a simple chocolate cake, although the texture of it is wonderfully light and fluffy, with a small crumb that is moist. For good measure, though, I soak the cake with a ginger simple syrup. The filling of the cake is a rich and deeply flavorful dark chocolate ganache infused with kaffir lime leaves and Thai bird chiles. The herbaceousness of the kaffir lime hits your tongue first, and as you swallow, the sweet heat of the chile creeps up. The heat is not overpowering, but it&#39;s definitely present. The cake is topped off with a classic Swiss meringue buttercream infused with a bit of green curry paste. What? Yes, green curry paste. You&#39;d think that green curry paste in frosting would be really strange, but you&#39;d be remiss to not try it. The kaffir lime and chile in the paste echo the flavors of the ganache filling, and the lemongrass, ginger, and galangal play off the flavors of the ginger soaking liquid. But there are two other ingredients in the paste - garlic and shallots - that lend a hit of earthiness and a savoriness that really rounds out the cake. And because cake is more fun with sprinkles, this one is topped off with peanuts that are dusted in coconut milk powder. The peanut sprinkles are totally optional, but because they&#39;re really easy to make (if you can find coconut milk powder), I always add them to lend a bit of crunch and contrast to the lush, silky cake.<br /><br />This cake has earned a spot as one of my favorites - give it a try and it might be one of yours, too.</p><h1><strong>Ingredients</strong></h1><pre>1 tablespoon unsalted butter1 tablespoon cocoa powder1 1/3 cups all-purpose flour1 teaspoon baking soda1/4 teaspoon baking powder1/4 teaspoon salt3/4 cup whole milk1/2 cup good quality cocoa powder1/4 cup coconut milk4 ounces (1 stick) butter1/2 cup turbinado sugar1/2 cup granulated sugar2  large eggs1 teaspoon grated ginger1/2 teaspoon vanillaFor the ginger simple syrup1/4 cup granulated sugar1/4 cup water1 pieces ginger, peeled and cut into 1/8 thick slicesFor the ganache filling2 small Thai bird chiles4 Kaffir lime leaves6 ounces heavy cream6 ounces 70% dark chocolateFor the green curry buttercream frosting5 large egg whites1 cup granulated sugar10 ounces unsalted butter, slightly cooler than room temperature3/4 teaspoon green curry paste (I use Maesri brand, as it&#39;s really flavorful and doesn&#39;t contain shrimp paste. I don&#39;t recommend the Taste of Thai green curry paste - it&#39;s really bland)For the coconut milk peanuts1/2 cup unsalted roasted peanuts2 tablespoons coconut milk powder</pre><h1><strong>Directions</strong></h1><ol>	<li>Make the chocolate cake</li>	<li>Set a rack in the middle of your oven and heat to 350 F. Use the 1 teaspoon of butter to grease two 9&quot; round cake pans. Divide the 1 tablespoon of cocoa powder between the pans and swirl it around the pan to evenly coat the bottom and sides. Bang out any excess cocoa powder.</li>	<li>In a medium bowl, sift together the flour, baking soda, baking powder, and salt.</li>	<li>Heat the whole milk to just below a boil (you can do this on the stove or, more easily, in the microwave). Put the cocoa powder in a smallish bow, pour the hot milk over it, and whisk until the cocoa is fully dissolved. Add the coconut milk and whisk to combine.</li>	<li>Put the butter, turbinado sugar, and granulated sugar in the bowl of a standing mixer fitted with the paddle attachment. Beat on medium-high speed for 3 minutes, making sure to scrape down the sides of the bowl every minute. Add the eggs and beat on medium-high speed for 30 seconds. Add the ginger and vanilla and mix until combined. Add the ginger and vanilla and mix until combined.</li>	<li>Add 1/3 of the flour mixture and mix on low speed until just barely combined. Scrape down the sides of the bowl, then add 1/2 of the cocoa-milk mixture. Mix on low speed until barely combined. Repeat with the remaining flour and milk, ending with the flour.</li></ol>",
                UrlSlug = "chocolate-thai-green-curry-cake",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Thai"),
                IsDeleted = false,
                ViewCount = 2000,
                RateCount = 300,
                TotalRate = 600,
                ImageSlider = "thai-green-curry-cake-s.jpg"
            };

            var post5 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Simple Sicilian-Style Grilled Steak",
                ShortDescription = "When I think of the Silician sauce salmoriglio, I typically think grilled fish. But it’s pungent and flavorful enough to stand up to red meat, and it makes a great, quick marinade—perfect for when you haven't planned ahead or just want a good steak fast.",
                ImageUrl = "grilled-steak.jpg",
                PostContent = "<p>How could I not love this? Garlic, lemon, red pepper flakes, fresh herbs&mdash;salmoriglio was practically made for me. As a marinade, it works beautifully on flank steak, gently flavoring and tenderizing the meat. As a sauce, it&#39;s even better. It was a great dipping sauce for asparagus as well as steak. Super easy, with lots of flavor, this is a truly great recipe and one I will use frequently.</p><h1><strong>Ingredients</strong></h1><p>3 garlic cloves, crushed</p><p>1 teaspoon kosher salt (for making garlic paste) + more, to taste, for marinade</p><p>2 tablespoons fresh oregano leaves, finely chopped</p><p>2 tablespoons fresh thyme leaves, finely chopped</p><p>1/4 teaspoon hot pepper flakes</p><p>1/2 cup olive oil</p><p>Juice and zest from 1 lemon</p><p>1.5 pounds flank, skirt, or hanger steak</p><h1><strong>Directions</strong></h1><ol>	<li>To make the salmoriglio, start by smashing together your garlic and salt with the side of your chef&#39;s knife, then work your knife back and forth to create a smooth paste. (Alternatively, you can do this step in a mortar and pestle.) In a small bowl, combine the garlic paste, oregano, thyme, and hot pepper flakes. Whisk in the olive oil, then add the lemon juice and zest. (Adding the olive oil first prevents the lemon juice from turning the herbs brown.) Season to taste with salt. Reserve about 1/3 cup of the salmoriglio to serve as a sauce.</li>	<li>To prep your flank steak, remove the steak from the refrigerator and place it on a plate or sheet pan. Rub the remaining salmoriglio evenly over both sides of the steak, making sure to work it in well. Leave to marinate for up to 1 hour. Meanwhile, prep your grill.</li>	<li>To grill your steak and serve, prep your grill for direct cooking over medium-high heat. Brush your grates clean. Grill the steak until cooked to your desired doneness, about 4 to 5 minutes on each side for medium-rare. Transfer to a cutting board and let rest for about 10 minutes. Thinly slice against the grain. Serve with the reserved salmoriglio on the side. Enjoy!</li></ol>",
                UrlSlug = "simple-sicilian-style-grilled-steak",
                Published = true,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Italian"),
                IsDeleted = false,
                ViewCount = 2000,
                RateCount = 600,
                TotalRate = 2000,
                ImageSlider = "grilled-steak-s.jpg"
            };

            var post6 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Cardamom Hot Chocolate ",
                ShortDescription = "Restorative after being out in subzero temps. I used cardamom, but you could use any spice that struck your fancy.",
                ImageUrl = "cardamom-hot-chocolate.jpg",
                PostContent = "<h1>Ingredients</h1><p>1 cup milk</p><p>3 green cardamom pods, crushed with the back of a knife</p><p>1 teaspoon unsalted butter</p><p>2 tablespoons dark chocolate, chopped</p><p>1/2 teaspoon vanilla</p><h1>Directions</h1><ol>	<li>In a small saucepan, heat milk and cardamom pods over medium-low heat. Let simmer for 10 minutes.</li>	<li>Heat butter and chocolate in another saucepan over medium-low heat. Stir until smooth.</li>	<li>Whisking constantly, add hot milk in a steady stream. Remove from heat and remove cardamom pods. Stir in vanilla and serve immediately.</li></ol>",
                UrlSlug = "cardamom-hot-chocolate",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Dessert"),
                IsDeleted = false,
                ViewCount = 2500,
                RateCount = 2000,
                TotalRate = 7000,
                ImageSlider = "cardamom-hot-chocolate-s.jpg"
            };
            var post7 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Thai Basil Stir-Fry Put Kaprow",
                ShortDescription = "Hands down this is my ultimate comfort food",
                ImageUrl = "thai-basil-stir-fry.jpg",
                PostContent = "<p>Served all day on the streets, though eaten mostly during breakfast and all throughout daytime. This one meal dish is stir-fried quickly and gobbled down even quicker. Pork, chilies, a few sauces thrown in, finishing with a big generous handful of thai basil, and topping off with a fried egg and a splash of fish chili sauce onto the rice. (Making it at home, I like to put the additional red/yellow bell pepper for color and nutrition)</p><h1>Ingredients</h1><p>300 grams of ground beef (can substitute with any other meat)&nbsp;</p><p>1 red onion, sliced thinly</p><p>3 to 5 thai chilies, chopped</p><p>3 to 5 cloves of garlic, peeled and chopped</p><p>1 tablespoon soy sauce</p><p>1 tablespoon oyster sauce</p><p>1 teaspoon fish sauce</p><p>1/2 teaspoon brown sugar</p><p>1 cup thai basil leaves, packed</p><p>Generous pinch of ground white pepper</p><p>1 fried egg per person, finishing with a dash of soy sauce</p><p>Fish chili sauce</p><p>2 to 3 thai chilies, chopped</p><p>1 tablespoon fish sauce</p><p>1/4 cup spring water</p><p>1 clove of garlic, chopped (optional)</p><h1><strong>Directions</h1><ol>	<li>Make the chili sauce, combine and set aside.</li>	<li>Heat the woke with 1 tbsp of oil, when oil just starts to smoke, add garlic, chili, sugar and onion; stir-fry until onions are soft and golden brown.</li>	<li>Add meat and stir-fry for around 5 minutes; add soy sauce, oyster sauce, fish sauce, and stir-fry until meat is well-cooked, another 2~3 minutes; take off heat and throw in basil leaves, stir-fry until well combined and wilted.</li>	<li>Garnish with ground white pepper and serve with a fried egg over thai jasmine rice. Accompany with fish sauce as needed.</li></ol>",
                UrlSlug = "thai-basil-stir-fry-put-kaprow",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Thai"),
                IsDeleted = false,
                ViewCount = 2500,
                RateCount = 2000,
                TotalRate = 4000,
                ImageSlider = "thai-basil-stir-fry-s.jpg"
            };
            var post8 = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "Short Rib Chili ",
                ShortDescription = "We love a good pot of chili, and our kitchen has turned out dozens of variations over the years. My husband is partial to a meaty, Alton Brown-style version, while I tend to favor a chili with lots of beans and sometimes no meat at all. ",
                ImageUrl = "short-rib-chili.jpg",
                PostContent = "<p>With the weather turning colder I decided to make chili my next project, and set out on a recent Sunday to come up with a version that would satisfy both of us. For the meat, I used boneless grass-fed beef short ribs, trimmed and cut into chunks. I made a puree of chiles and spices, added fire-roasted tomatoes and some rich dark beer, and let everything cook low and slow for the better part of the day. I added some crushed tortilla chips for texture and a hint of toasty corn flavor, and a hit of fresh lime juice at the end for brightness and balance. And after my pot of chili had cooked for the better part of the day, I cooled it down and let it sit overnight. We ate it on the following Monday with a bevy of garnishes, and I have to tell you, it was so worth the wait.</p><h1>Ingredients</h1><p>1/2 pound dried small red beans</p><p>2 1/2 cups water</p><p>1 bay leaf</p><p>1 small onion, halved, unpeeled</p><p>2 dried ancho chiles</p><p>2 dried guajillo chiles</p><p>2 cups boiling water</p><p>1 tablespoon whole coriander seeds</p><p>1 tablespoon whole cumin seeds</p><p>1 teaspoon coarse salt</p><p>1/2 teaspoon ground cinnamon</p><p>1/2 teaspoon chipotle powder</p><p>1 tablespoon cocoa powder (I used Valrhona)</p><p>1 whole fire-roasted red bell pepper</p><p>1 Kosher or sea salt</p><p>1 1/2 pounds boneless beef short ribs, trimmed</p><p>1 splash grapeseed or other neutral oil</p><p>2 cups diced yellow onion</p><p>2 large cloves garlic, peeled and smashed</p><p>1 tablespoon dried marjoram or Mexican oregano</p><p>1 tablespoon double-concentrated tomato paste</p><p>1 28 oz. can fire roasted tomatoes with juice, gently crushed</p><p>1 cup chocolate stout (I used Brooklyn Brewery&#39;s Black Chocolate Stout)</p><p>1/2 cup crushed tortilla chips</p><p>1 lime, juiced</p><p>1 handful grated sharp cheddar or jack cheese</p><p>1 teaspoon sour cream</p><p>1 handful fresh cilantro leaves</p><p>1 handful quick pickled red onion</p><p>1 handful fresh or pickled jalapeno peppers</p><p>1 handful diced fresh avocado</p><p>1 handful thinly sliced radishes</p><p>1 handful tortilla chips or warm tortillas</p><p>1 dash your favorite hot pepper sauce</p><h1>Directions</h1><ol>	<li>Pick over the beans to remove any stones or debris, and place them in a large pot. Add the water, bay leaf and onion, cover the pot, and bring it to a boil. Let boil for 2 minutes, then turn off the heat and let the beans stand, undrained, for an hour. Discard the onion and bay leaf. (Note: the beans should be fairly tender at this point, though older beans may need more soaking time.)</li>	<li>Put on a pair of latex gloves. (No, seriously. Trust me on this.) Using kitchen shears, snip off the stems of the dried peppers and shake out most of the seeds (unless you like a fierier chili, in which case leave in as many as you like). Toast the peppers in a dry skillet until they are fragrant and beginning to soften, then place them in a bowl and cover them with the 2 cups of boiling water. Let soak until they are very soft.</li>	<li>Toast the coriander and cumin seeds in the same dry skillet until fragrant. Transfer to a mortar and pestle, add the coarse salt, and grind. Place the softened peppers with their soaking liquid in a blender, adding the ground coriander/cumin mixture, the cinnamon, the chipotle powder, the cocoa powder, and the roasted bell pepper. Puree until smooth and set aside.</li>	<li>Cut the short ribs into bite-sized chunks, season well with salt, and set aside. Place a small amount of oil in a deep, heavy-bottomed pot and warm until shimmering. Brown the short rib pieces in batches, removing them to a plate or platter as you finish browning.</li>	<li>Add the chopped onion and a pinch of salt and cook until translucent. Add the garlic and marjoram or Mexican oregano and cook until fragrant. Clear a space in the bottom of the pot, add the tomato paste, and cook for a minute until it gets a little caramelized before stirring it through the onion mixture.</li>	<li>Return the short ribs to the pot with any juices that have accumulated on the plate or platter, then add the chile puree, the beans with their cooking liquid, and the fire-roasted tomatoes. Add the stout and stir to incorporate. Cover and simmer over low heat for at least 3-4 hours, until the beans and beef are fully tender (this is actually best if you cook it low and slow ahead of time, even one or two days in advance of when you&rsquo;re actually going to serve it).</li>	<li>Add the crushed tortilla chips about an hour before serving, stirring them in so they break down and thicken the chili (and add a lovely toasty corn flavor). Taste for salt and add a bit more if necessary, stir in the fresh lime juice off the heat, then serve with garnishes and plenty of cold beer.</li></ol><p>&nbsp;</p>",
                UrlSlug = "short-rib-chili",
                Published = false,
                PublishedDate = DateTime.Now,
                Category = categories.Single(x => x.Name == "Mexican"),
                IsDeleted = false,
                ViewCount = 3000,
                RateCount = 2000,
                TotalRate = 7000,
                ImageSlider = "short-rib-chili-s.jpg"
            };

            var tags = new List<Tag>()
            {
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Beef",
                    UrlSlug = "beef",
                    Description="",
                    Count = 3,
                    Posts = new List<Post>(){post8,post7,post5},
                    IsDeleted = false
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Fruits",
                    UrlSlug = "fruits",
                    Description="",
                    Count = 2,
                    Posts = new List<Post>(){post2},
                    IsDeleted = false
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rice",
                    UrlSlug = "rice",
                    Description="",
                    Count = 3,
                    Posts = new List<Post>(){post7},
                    IsDeleted = false
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mushrooms",
                    UrlSlug = "mushrooms",
                    Description="",
                    Count = 3,
                    Posts = new List<Post>(){post1},
                    IsDeleted = false
                },
                new Tag()
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate",
                    UrlSlug = "chocolate",
                    Description="",
                    Count = 3,
                    Posts = new List<Post>(){post4,post5, post6},
                    IsDeleted = false
                }
            };

            context.Tags.AddRange(tags);
            context.SaveChanges();
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentity(JustBlogContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";
            const string contributerRole = "Contributer";
            const string visiter = "User";

            #region Create Role
            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            //Create Role Contributer if it does not exist
            var contributer = roleManager.FindByName(contributerRole);
            if(contributer == null)
            {
                contributer = new IdentityRole(contributerRole);
                var roleResult = roleManager.Create(contributer);
            }

            //Create Role User if it does not exist
            var userRole = roleManager.FindByName(visiter);
            if (userRole == null)
            {
                userRole = new IdentityRole(visiter);
                var roleResult = roleManager.Create(userRole);
            }
            #endregion

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}