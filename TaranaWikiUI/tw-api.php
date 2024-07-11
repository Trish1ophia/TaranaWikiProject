<?php
require_once 'vendor/autoload.php';

use Mediawiki\Api;

class TaranaWikiApi
{
    private $api;

    public function __construct()
    {
        $this->api = new Api('http://localhost/wiki/api.php'); // Replace with your MediaWiki API URL
    }

    public function getArticles()
    {
        $response = $this->api->get(
            array(
                'action' => 'query',
                'list' => 'allpages',
                'aplimit' => 100
            )
        );

        return $response->getResult();
    }

    public function getArticle($title)
    {
        $response = $this->api->get(
            array(
                'action' => 'query',
                'titles' => $title
            )
        );

        return $response->getResult();
    }
}