import { apiGet, apiPost } from './client'
import type { Link } from '../types/link'

export function fetchLinks(): Promise<Link[]> {
  return apiGet<Link[]>('/api/links')
}

export async function fetchLink(id: string): Promise<Link | undefined> {
  const links = await fetchLinks()
  return links.find((link) => link.id === id)
}

export function createLink(targetUrl: string): Promise<Link> {
  return apiPost<Link>('/api/links', { targetUrl })
}
