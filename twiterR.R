#extraccion de twitter
#Obtiene los tweets de un usuario, los limpia y almacena en la base de datos


#pidiendo acceso 
# Asking for access
library(RPostgreSQL)
library(ROAuth)
library(RCurl)
library(twitteR)

con=dbConnect(PostgreSQL(), user="postgres", password="12345", dbname="prograIA")

download.file(url="http://curl.haxx.se/ca/cacert.pem",destfile="cacert.pem")  

requestURL <- "https://api.twitter.com/oauth/request_token"
accessURL <- "https://api.twitter.com/oauth/access_token"
authURL <- "https://api.twitter.com/oauth/authorize"

consumerKey <- "q6EQNL9cfa0tyEW8PM8jJ0zF7"
consumerSecret <- "GfiLh8GsvSdkXTQj1N0nW0vW6Iq8PqU0QRuL9qVKUrn6icy08U"
accessToken <- "771436437803823104-4uT6eOHmZDQDHaCjBAO03oo5JArlpTF"
accessSecret <- "EjWFfw4QUlyMXDHbyF7lRgznfrZhGWXY6tI5sM9Tj6SuG"

setup_twitter_oauth(consumerKey, consumerSecret, accessToken, accessSecret)  

# retrieve the first 100 tweets (or all tweets if fewer than 100)
# from the user timeline of @rdatammining
usuario = dbGetQuery(con, "select nombre from usuarioTwitter order by id desc limit 1")
some_tweets = searchTwitter(usuario, n=5, lang='es')
tweets = sapply(some_tweets, function(x) x$getText())


# remove retweet entities
tweets = gsub('(RT|via)((?:\\b\\W*@\\w+)+)', '', tweets)
# remove at people
tweets = gsub('@\\w+', '', tweets)
# remove punctuation

tweets = gsub('\n', '', tweets)

tweets = gsub('[[:punct:]]', '', tweets)
# remove numbers
tweets = gsub('[[:digit:]]', '', tweets)
# remove html links
tweets = gsub('http\\w+', '', tweets)
# remove unnecessary spaces
tweets = gsub('[ \t]{2,}', '', tweets)
tweets = gsub('^\\s+|\\s+$', '', tweets)

tweets = tolower(tweets)

tweets

i = 1
while(i <= length(tweets))
{
  consulta = paste(paste(paste("INSERT into tweets (tweet, idusario) values ('", tweets[i], sep = ""),
                         usuario, sep = "' , '"), ")", sep = "' ")
  agregarTweets <- dbGetQuery(con, consulta)
  i = i + 1
}

