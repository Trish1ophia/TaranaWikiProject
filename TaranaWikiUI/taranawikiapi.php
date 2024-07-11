<?php

class TaranaWikiApi {
    private $apiUrl;
    private $userName;
    private $password;

    public function __construct($apiUrl, $userName, $password) {
        $this->apiUrl = $apiUrl;
        $this->userName = $userName;
        $this->password = $password;
    }

    public function login() {
        $params = array(
            'action' => 'login',
            'lgname' => $this->userName,
            'lgpassword' => $this->password,
            'format' => 'json'
        );
        $response = $this->makeRequest($params);
        $data = json_decode($response, true);
        return $data['login']['token'];
    }

    public function search($title) {
        $params = array(
            'action' => 'query',
            'list' => 'search',
            'srsearch' => $title,
            'format' => 'json'
        );
        $response = $this->makeRequest($params);
        $data = json_decode($response, true);
        return $data['query']['search'];
    }

    public function getPage($title) {
        $params = array(
            'action' => 'parse',
            'page' => $title,
            'format' => 'json'
        );
        $response = $this->makeRequest($params);
        $data = json_decode($response, true);
        return $data['parse']['text']['*'];
    }

    public function createPage($title, $content) {
        $params = array(
            'action' => 'edit',
            'title' => $title,
            'text' => $content,
            'token' => $this->login(),
            'format' => 'json'
        );
        $response = $this->makeRequest($params);
        $data = json_decode($response, true);
        return $data['edit']['result'];
    }

    public function updatePage($title, $content) {
        $params = array(
            'action' => 'edit',
            'title' => $title,
            'text' => $content,
            'token' => $this->login(),
            'format' => 'json'
        );
        $response = $this->makeRequest($params);
        $data = json_decode($response, true);
        return $data['edit']['result'];
    }

    public function deletePage($title) {
        $params = array(
            'action' => 'delete',
            'title' => $title,
            'token' => $this->login(),
            'format' => 'json'
        );
        $response = $this->makeRequest($params);
        $data = json_decode($response, true);
        return $data['delete']['result'];
    }

    private function makeRequest($params) {
        $url = $this->apiUrl . '?' . http_build_query($params);
        $ch = curl_init($url);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
        $response = curl_exec($ch);
        curl_close($ch);
        return $response;
    }
}

// Example usage:
$api = new TaranaWikiApi('https://localhost/w/api.php', 'your-username', 'your-password');
$token = $api->login();
$pageContent = $api->getPage('YourPageTitle');
echo $pageContent;
