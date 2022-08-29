# HTML
* Hypertext Markup Language
* Another markup language so that means it is just telling the computer what to do and not compiling it into machine code
* Very similar to xml (our .csproj files) but HTML is used to define the structure of our webpages
* Our browsers are essentially experts at reading this files and interpreting it to display something on the browser
* We are currently on version HTML 5

## HTML elements
* so like XML, it uses tags to define what something should be displayed and instead of calling them "tags" we also call them HTML elements
* They are, for the most part, a basic graphical unit of something you want to display/structure on your web page

# PUT NOTES FOR INLINE AND BLOCK 

## HTML attributes
* They are used to provide extra information that the tag can use
* Ex: img tag using src attribute to find a specific image to display

## Web Accessiblity
* In the past only a computer has access to a website and so usually websites are created for a pc only. That's not the case anymore.
* So Web accessiblity is configuring your website in a way so it is also readable beyond pc users such as phone, tablets, gaming consoles, etc. 
* This is usually done by manipulating CSS 

# CSS
* Cascading Style Sheets
    * Cascading is in the name because it uses a cascading algorithm to determine what style it should apple (more on this later)
* A way to stop making your website looking like it came from the 90s

## CSS Selectors
* Before applying styles everywhere, we need a way to select specific or group of HTMl elements first so we give them their own type of look
* There are three basic fundamental selectors we should keep in mind:
1. Element selector - When you want to select multiple elements of the same tag
2. Class selector - When you want to select multiple elements of differing tag by using the class attribute
3. Id selector - When you want to select one (mostly) or a couple elements using the id attribute

## Different ways to include CSS
* Inline CSS
    * Applies CSS to a single element
    * It uses the style attribute
* Internal CSS
    * Applies CSS by using the style tag inside of a HTML doc
    * Used to apply multiple css to multiple elements
* External CSS
    * Creating an external .css file to apply css to multiple HTML docs (you can just apply it to one HTML but that kind of defeats the purpose of using an external css)
    * HTML doc must use the link tag to reference the external css
    * Used to apply multiple css to multiple elements in multiple HTML docs
        * So useful to create a universal theme of your website

# Responsive Web Design
* Making your elements not have rigid in size but changes its size based on the viewport
    * Viewport is just how big the window of the browser is (small for phones, big for computers)
* Useful to accomodate for every devices out there that might access your website
* We will leverage Bootstrap libraries for pre-made css files to implement this design
    * Click [here](https://getbootstrap.com/docs/5.1/getting-started/introduction/) for Bootstrap documentation

